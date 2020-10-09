namespace CourseStreamSelection.Model
{
    public class ProfessorRating
    {
        public string Professor { get; }
        public double Rating { get; set; }

        public ProfessorRating(string professor, double rating = 0)
        {
            Professor = professor;
            Rating = rating;
        }
    }
}