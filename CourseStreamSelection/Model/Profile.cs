using CourseStreamSelection.Databases;
using CourseStreamSelection.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CourseStreamSelection.Model
{
    public sealed class Profile : INamedObject
    {
        public string Name { get; set; }
        public Dictionary<Course, double?> CourseRatings { get; }
        public Dictionary<string, double?> ProfessorRatings { get; }

        [JsonIgnore]
        public bool HasRatedAllCourses => !CourseRatings.Any(kvp => kvp.Value == null);
        [JsonIgnore]
        public bool HasRatedAllProfessors => !ProfessorRatings.Any(kvp => kvp.Value == null);

        [JsonIgnore]
        public bool HasRatedEverything => HasRatedAllCourses && HasRatedAllProfessors;

        public Profile(string name)
            : this(name, new Dictionary<Course, double?>(), new Dictionary<string, double?>()) { }
        private Profile(string name, Dictionary<Course, double?> courseRatings, Dictionary<string, double?> professorRatings)
        {
            Name = name;
            CourseRatings = courseRatings;
            ProfessorRatings = professorRatings;
        }

        public void AddRatingEntriesFromCourses(CoursesInformation coursesInformation)
        {
            AddRatingEntriesFromCourses(coursesInformation.Courses, coursesInformation.Professors);
        }
        public void AddRatingEntriesFromCourses(IEnumerable<Course> courses, IEnumerable<string> professors)
        {
            foreach (var c in courses)
                CourseRatings.Add(c, null);
            foreach (var p in professors)
                ProfessorRatings.Add(p, null);
        }

        // Massive fucking function, should it really be that massive?
        public CourseStreamSelectionResults GetCourseStreamSelectionResults()
        {
            if (!HasRatedEverything)
                return null;

            var normalizedCourseRatings = CourseRatings.ToNonNullableValueDictionary().Normalize();
            var normalizedProfessorRatings = ProfessorRatings.ToNonNullableValueDictionary().Normalize();

            var coursesInformation = MainDatabase.Instance.CoursesInformation;

            var currentRatings = new CourseStreamSelectionResults();
            var averagedInitialRatings = new CourseStreamSelectionResults();
            // TODO: Use this somewhere?
            var hours = new CourseStreamSelectionResults();

            var mandatoryCoursesCount = new CourseStreamSelectionResults();
            var optionalCoursesCount = new CourseStreamSelectionResults();

            // Store some count metadata to perform calculations more efficiently later on
            for (int i = 0; i < 9; i++)
            {
                mandatoryCoursesCount[i] = coursesInformation.GetMandatoryCoursesInStream(i).Where(c => c.HasProfessors).Count();
                optionalCoursesCount[i] = coursesInformation.GetOptionalCoursesInStream(i).Where(c => c.HasProfessors).Count();
            }

            // First iteration, note mandatory course ratings
            for (int i = 0; i < 9; i++)
            {
                var mandatoryCourses = coursesInformation.GetMandatoryCoursesInStream(i).Where(c => c.HasProfessors);
                foreach (var mandatoryCourse in mandatoryCourses)
                {
                    currentRatings[i] += GetCourseRating(mandatoryCourse, normalizedCourseRatings, normalizedProfessorRatings);
                    hours[i] += mandatoryCourse.Hours;
                }
                averagedInitialRatings[i] = currentRatings[i] / mandatoryCoursesCount[i];
            }

            // Second iteration, analyze correlation with other streams
            for (int i = 0; i < 9; i++)
            {
                var optionalCourseResults = new CourseStreamSelectionResults();
                var averagedOptionalCourseResults = new CourseStreamSelectionResults();

                double maxAverageRating = 0;
                int maxAverageRatingIndex = -1;
                int maxAverageRatingSelectedOptionalCourses = 0;

                for (int j = 0; j < 9; j++)
                {
                    if (i == j)
                        continue;

                    var mandatoryCoursesA = coursesInformation.GetMandatoryCoursesInStream(i);
                    var mandatoryCoursesB = coursesInformation.GetMandatoryCoursesInStream(j);
                    var uniqueMandatoryCourses = new HashSet<Course>(mandatoryCoursesA.Concat(mandatoryCoursesB).Where(c => c.HasProfessors));

                    int remainingECTS = 3 * 30 - 15 - uniqueMandatoryCourses.Sum(c => c.ECTS);

                    if (remainingECTS <= 0)
                    {
                        // This stream combination results in at least 75 ECTS from the mandatory courses only
                        continue;
                    }

                    var optionalCoursesA = coursesInformation.GetOptionalCoursesInStream(i);
                    var optionalCoursesB = coursesInformation.GetOptionalCoursesInStream(j);
                    var uniqueOptionalCourses = new HashSet<Course>(optionalCoursesA.Concat(optionalCoursesB).Where(c => c.HasProfessors));

                    if (!uniqueOptionalCourses.Any())
                        continue;

                    var optionalCourseRatings = new Dictionary<Course, double>();

                    foreach (var optionalCourse in uniqueOptionalCourses)
                    {
                        optionalCourseRatings.Add(optionalCourse, GetCourseRating(optionalCourse, normalizedCourseRatings, normalizedProfessorRatings));
                    }

                    var sortedOptionalCourses = uniqueOptionalCourses.ToList();
                    sortedOptionalCourses.Sort((a, b) => optionalCourseRatings[b].CompareTo(optionalCourseRatings[a]));

                    int selectedOptionalCourses = 0;
                    do
                    {
                        var selected = sortedOptionalCourses[selectedOptionalCourses];
                        optionalCourseResults[j] += optionalCourseRatings[selected];
                        remainingECTS -= selected.ECTS;
                        selectedOptionalCourses++;
                    }
                    while (remainingECTS > 0 && selectedOptionalCourses < sortedOptionalCourses.Count);

                    if (remainingECTS > 0)
                        continue;

                    double averageRating = averagedOptionalCourseResults[j] = optionalCourseResults[j] / selectedOptionalCourses;
                    if (averageRating > maxAverageRating)
                    {
                        maxAverageRating = averageRating;
                        maxAverageRatingIndex = j;
                        maxAverageRatingSelectedOptionalCourses = selectedOptionalCourses;
                    }
                }

                // This is probably ridiculously long
                if (maxAverageRatingIndex > -1)
                    currentRatings[i] = (currentRatings[i] + optionalCourseResults[maxAverageRatingIndex]) / (mandatoryCoursesCount[i] + maxAverageRatingSelectedOptionalCourses);
                else
                    currentRatings[i] = averagedInitialRatings[i];
            }

            currentRatings.NormalizeUpper();

            return currentRatings;
        }

        private static double GetCourseRating(Course course, Dictionary<Course, double> courses, Dictionary<string, double> professors)
        {
            double? professor2Rating = null;
            if (course.Professor2 != null)
                professor2Rating = professors[course.Professor2];

            return GetCourseRating(courses[course], professors[course.Professor1], professor2Rating);
        }
        private static double GetCourseRating(double courseRating, double professor1Rating, double? professor2Rating)
        {
            return courseRating * GetProfessorMultiplier(professor1Rating) * GetProfessorMultiplier(professor2Rating ?? 1);
        }
        private static double GetProfessorMultiplier(double professorRating) => professorRating * 0.4 + 0.6;

        public Profile Clone(string newName)
        {
            return new Profile(newName, new Dictionary<Course, double?>(CourseRatings), new Dictionary<string, double?>(ProfessorRatings));
        }

        public override bool Equals(object obj) => obj is Profile p && Name == p.Name;
        public override int GetHashCode() => Name.GetHashCode();
        public override string ToString() => Name;
    }
}
