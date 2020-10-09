using System.ComponentModel;

namespace CourseStreamSelection.Model
{
    [TypeConverter(typeof(CourseTypeConverter))]
    public sealed class Course : INamedObject
    {
        public string Code { get; }
        public string Name { get; }

        public int ECTS { get; }
        public int Hours { get; }
        public CourseType Type { get; }

        public int Semester { get; }

        public AvailableCourseStreams AvailableCourseStreams { get; }

        public CourseProfessors CourseProfessors { get; }

        public string Professor1 => CourseProfessors.Professor1;
        public string Professor2 => CourseProfessors.Professor2;

        public bool HasProfessors => CourseProfessors.HasProfessors;

        // Too long constructor, innit
        public Course(string code, string name, int ects, int hours, CourseType type, int semester, AvailableCourseStreams streams, string professor1, string professor2)
            : this(code, name, ects, hours, type, semester, streams, new CourseProfessors(professor1, professor2)) { }
        public Course(string code, string name, int ects, int hours, CourseType type, int semester, AvailableCourseStreams streams, CourseProfessors courseProfessors)
        {
            Code = code;
            Name = name;
            ECTS = ects;
            Hours = hours;
            Type = type;
            Semester = semester;
            AvailableCourseStreams = streams;
            CourseProfessors = courseProfessors;
        }

        public string GetCodeWithName() => $"{Code} - {Name}";
        public override string ToString() => Name;
    }
}
