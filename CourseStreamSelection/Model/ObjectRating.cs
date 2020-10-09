namespace CourseStreamSelection.Model
{
    public abstract class ObjectRating
    {
        public double Rating { get; set; }

        protected ObjectRating(double rating = 0)
        {
            Rating = rating;
        }
    }
}