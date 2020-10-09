namespace CourseStreamSelection.Model
{
    public class CourseRating
    {
        public Course Course { get; }
        public double Rating { get; set; }

        public CourseRating(Course course, double rating = 0)
        {
            Course = course;
            Rating = rating;
        }
    }
}