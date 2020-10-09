using CourseStreamSelection.Extensions;

namespace CourseStreamSelection.Model
{
    public class CourseStreamSelectionResults
    {
        private double[] results;

        public double[] Results => results.CopyArray();

        public CourseStreamSelectionResults() : this(new double[9]) { }
        public CourseStreamSelectionResults(double[] otherResults)
        {
            results = otherResults.CopyArray();
        }

        public void Normalize() => results = results.Normalize();
        public void NormalizeUpper() => results = results.NormalizeUpper();
        public void NormalizeLower() => results = results.NormalizeLower();

        public CourseStreamSelectionResults Clone() => new CourseStreamSelectionResults(results);

        public double this[int index]
        {
            get => results[index];
            set => results[index] = value;
        }
    }
}
