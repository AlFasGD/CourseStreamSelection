using CourseStreamSelection.Model;
using NUnit.Framework;

namespace CourseStreamSelection.Tests.Model
{
    public class CourseStreamSelectionResultsTests
    {
        [Test]
        public void NormalizeTest()
        {
            var unnormalizedResults = new double[] { -12, -9, -3, 9, -15, 15, 12, -3, 0 };
            var results = new CourseStreamSelectionResults(unnormalizedResults);

            results.Normalize();

            Assert.AreEqual(new double[] { 0.1, 0.2, 0.4, 0.8, 0, 1, 0.9, 0.4, 0.5 }, results.Results);
        }
        [Test]
        public void NormalizeUpperTest()
        {
            var unnormalizedResults = new double[] { 0.2, 0.1, 0.3, 0.4, 0.5, 0.2, 0.15 };
            var results = new CourseStreamSelectionResults(unnormalizedResults);

            results.NormalizeUpper();

            Assert.AreEqual(new double[] { 0.4, 0.2, 0.6, 0.8, 1, 0.4, 0.3 }, results.Results);
        }
    }
}
