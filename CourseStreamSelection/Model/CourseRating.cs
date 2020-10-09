namespace CourseStreamSelection.Model
{
    public class CourseRating : ObjectRating
    {
        public Course Course { get; }

        public CourseRating(Course course, double rating = 0)
            : base(rating)
        {
            Course = course;
        }
    }
}