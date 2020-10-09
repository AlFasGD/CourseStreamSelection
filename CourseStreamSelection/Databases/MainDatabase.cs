using CourseStreamSelection.Extensions;
using CourseStreamSelection.Model;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourseStreamSelection.Databases
{
    // I just chose to implement it as a singleton, what's the deal

    public sealed class MainDatabase
    {
        #region File Locations
        private const string courseInformationSpreadsheetLocation = @"Resources\Μαθήματα Ροής.xlsx";
        private const string profileDataLocation = @"UserData\profiles.json";
        #endregion

        #region Static Stuff
        public static MainDatabase Instance { get; private set; }

        static MainDatabase()
        {
            Instance = new MainDatabase();
            Instance.LoadPostInitialization();
        }
        #endregion

        #region Instance
        public CoursesInformation CoursesInformation { get; private set; }

        public Dictionary<string, string> CourseStreams => CoursesInformation.CourseStreams;
        public string[] CourseStreamTitles => CoursesInformation.CourseStreamTitles;
        public List<string> Professors => CoursesInformation.Professors;
        public List<Course> Courses => CoursesInformation.Courses;

        private HashSet<Profile> profiles;

        public List<Profile> Profiles => profiles.ToList();
        public int ProfileCount => profiles.Count;

        // The constructor is empty so that the instance is immediately initialized,
        // allowing for other operations to interact with this instance without receiving nulls
        private MainDatabase() { }

        private void LoadPostInitialization()
        {
            LoadCourses();
            LoadProfiles();
        }

        public Profile CreateNewProfile(string name)
        {
            var newProfile = new Profile(name);
            if (!profiles.Add(newProfile))
                return null;

            newProfile.AddRatingEntriesFromCourses(Courses, Professors);

            SaveProfiles();
            return newProfile;
        }

        public bool RemoveProfile(string name) => RemoveProfile(GetProfile(name));
        public bool RemoveProfile(Profile profile)
        {
            if (profile == null)
                return false;

            profiles.Remove(profile);
            SaveProfiles();
            return true;
        }

        public bool RenameProfile(string originalName, string newName) => RenameProfile(GetProfile(originalName), newName);
        public bool RenameProfile(Profile profile, string newName)
        {
            if (GetProfile(newName) != null)
                return false;

            // Remove and read the profile to capture and update its hash code
            profiles.Remove(profile);
            profile.Name = newName;
            profiles.Add(profile);
            SaveProfiles();
            return true;
        }

        public Profile Clone(string name) => Clone(GetProfile(name));
        public Profile Clone(Profile profile)
        {
            var baseName = profile.Name.RemoveLastNumber(out int n);
            int currentVersion = 1;

            if (baseName.EndsWith(' '))
            {
                baseName = baseName.Remove(baseName.Length - 1);
                currentVersion = n;
            }
            else
                baseName = profile.Name;
            
            while (GetProfile($"{baseName} {currentVersion}") != null)
                currentVersion++;

            var p = profile.Clone($"{baseName} {currentVersion}");
            profiles.Add(p);
            return p;
        }

        public Profile GetProfile(string name) => profiles.FirstOrDefault(p => p.Name == name);
        public Course GetCourse(string name) => CoursesInformation.GetCourse(name);

        #region Load/Save Operations
        private void LoadCourses()
        {
            using (var package = new ExcelPackage(new FileInfo(courseInformationSpreadsheetLocation)))
            {
                #region Courses Sheet
                var coursesSheet = package.Workbook.Worksheets[0];

                var courses = new List<Course>();

                // This is awful, but the whole process is awful too
                int currentRow = 3;
                int semester = 6;
                while (true)
                {
                    var code = coursesSheet.Cells[currentRow, 1].Value?.ToString();

                    if (string.IsNullOrEmpty(code))
                        break;

                    var name = coursesSheet.Cells[currentRow, 2].Value.ToString();
                    var ects = int.Parse(coursesSheet.Cells[currentRow, 3].Value.ToString());
                    var hours = int.Parse(coursesSheet.Cells[currentRow, 4].Value.ToString());
                    var stringType = coursesSheet.Cells[currentRow, 5].Value.ToString();

                    var streams = new AvailableCourseStreams();
                    for (int i = 0; i < 9; i++)
                    {
                        var availability = coursesSheet.Cells[currentRow, 6 + i].Value?.ToString();
                        streams[i] = availability switch
                        {
                            "Υ" => CourseStreamAvailability.Mandatory,
                            "Ε" => CourseStreamAvailability.Optional,
                            _ => CourseStreamAvailability.None
                        };
                    }    

                    var professor1 = coursesSheet.Cells[currentRow, 15].Value.ToString();

                    string professor2 = null;
                    if (!coursesSheet.Cells[currentRow, 15].Merge)
                        professor2 = coursesSheet.Cells[currentRow, 16].Value.ToString();

                    var type = stringType switch
                    {
                        "ΥΚΕ" => CourseType.MandatoryInCourseStream,
                        "ΓΕ" => CourseType.Mandatory,
                        "Ε" => CourseType.Optional,
                    };

                    var course = new Course(code, name, ects, hours, type, semester, streams, professor1, professor2);
                    courses.Add(course);

                    if (coursesSheet.Cells[currentRow, 1].Style.Border.Bottom.Style != ExcelBorderStyle.None)
                        semester++;

                    currentRow++;
                }
                #endregion

                #region Course Streams Sheet
                var courseStreamsSheet = package.Workbook.Worksheets[1];

                var courseStreams = new Dictionary<string, string>(9);
                for (int i = 0; i < 9; i++)
                {
                    var streamIndex = courseStreamsSheet.Cells[2, 2 + i * 2].Value.ToString();
                    var streamTitle = courseStreamsSheet.Cells[2, 3 + i * 2].Value.ToString();

                    courseStreams.Add(streamIndex, streamTitle);
                }
                #endregion

                CoursesInformation = new CoursesInformation(courses, courseStreams);
            }
        }

        private void LoadProfiles()
        {
            if (File.Exists(profileDataLocation))
                profiles = JsonConvert.DeserializeObject<HashSet<Profile>>(File.ReadAllText(profileDataLocation));
            else
                profiles = new HashSet<Profile>();
        }
        public async Task SaveProfiles()
        {
            File.WriteAllText(profileDataLocation, JsonConvert.SerializeObject(profiles, Formatting.Indented));
        }
        #endregion
        #endregion
    }
}
