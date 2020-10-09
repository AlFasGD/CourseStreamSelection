namespace CourseStreamSelection.Model
{
    public class ProfessorRating : ObjectRating
    {
        public string Professor { get; }

        public ProfessorRating(string professor, double rating = 0)
            : base(rating)
        {
            Professor = professor;
        }
    }
}