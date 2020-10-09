using CourseStreamSelection.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace CourseStreamSelection.Model
{
    public sealed class CoursesInformation
    {
        private List<Course> courses;
        private List<Course>[] mandatoryCoursesByStreams = new List<Course>[9];
        private List<Course>[] optionalCoursesByStreams = new List<Course>[9];

        private HashSet<string> professors = new HashSet<string>();

        private string[] courseStreamTitles;
        private Dictionary<string, string> courseStreams = new Dictionary<string, string>();

        public List<string> Professors => professors.ToList();
        public List<Course> Courses => new List<Course>(courses);

        public List<Course> MandatoryCourses => courses.Where(c => c.Type == CourseType.Mandatory).ToList();
        public List<Course> MandatoryStreamCourses => courses.Where(c => c.Type == CourseType.MandatoryInCourseStream).ToList();
        public List<Course> OptionalCourses => courses.Where(c => c.Type == CourseType.Optional).ToList();

        public Dictionary<string, string> CourseStreams => new Dictionary<string, string>(courseStreams);
        public string[] CourseStreamTitles => courseStreamTitles.CopyArray();

        public CoursesInformation(List<Course> c, Dictionary<string, string> streams)
        {
            InitializeArray(mandatoryCoursesByStreams);
            InitializeArray(optionalCoursesByStreams);

            courses = c;
            courseStreams = streams;
            courseStreamTitles = courseStreams.Values.ToArray();
            AnalyzeCourseInformation();
        }

        public List<Course> GetMandatoryCoursesInStream(int index) => new List<Course>(mandatoryCoursesByStreams[index]);
        public List<Course> GetOptionalCoursesInStream(int index) => new List<Course>(optionalCoursesByStreams[index]);

        public Course GetCourse(string name) => courses.FirstOrDefault(c => c.Name == name);
        public string GetCourseStreamTitle(int index) => courseStreamTitles[index];

        private void AnalyzeCourseInformation()
        {
            foreach (var c in courses)
            {
                var available = c.AvailableCourseStreams;
                var mandatory = available.MandatoryIndices;
                var optional = available.OptionalIndices;

                foreach (var i in mandatory)
                    mandatoryCoursesByStreams[i].Add(c);
                foreach (var i in optional)
                    optionalCoursesByStreams[i].Add(c);

                professors.AddRange(c.CourseProfessors.Professor1, c.CourseProfessors.Professor2);
            }

            professors.Remove(null);
            professors.Remove("-");
        }

        private static void InitializeArray<T>(List<T>[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
                ar[i] = new List<T>();
        }
    }
}
