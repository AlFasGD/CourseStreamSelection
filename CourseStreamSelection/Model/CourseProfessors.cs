namespace CourseStreamSelection.Model
{
    public class CourseProfessors
    {
        public string Professor1 { get; }
        public string Professor2 { get; }

        public bool HasProfessors => Professor1 != null || Professor2 != null;

        public CourseProfessors() : this(null, null) { }
        public CourseProfessors(string professor1) : this(professor1, null) { }
        public CourseProfessors(string professor1, string professor2)
        {
            if (professor1 == "-")
                professor1 = null;
            if (professor2 == "-")
                professor2 = null;

            if (professor1 == null && professor2 != null)
                Professor1 = professor2;
            else
            {
                Professor1 = professor1;
                Professor2 = professor2;
            }
        }

        public override string ToString()
        {
            if (Professor1 == null)
                return "-";
            if (Professor2 == null)
                return Professor1;
            return $"{Professor1}, {Professor2}";
        }
    }
}