using CourseStreamSelection.Model;
using NUnit.Framework;

namespace CourseStreamSelection.Tests.Model
{
    public class AvailableCourseStreamsTests
    {
        [Test]
        public void DataTest()
        {
            const int streams = 9;

            var currentAvailabilities = new CourseStreamAvailability[streams];
            var availabilitiesStruct = new AvailableCourseStreams();

            AssertAvailabilities();

            AdjustAssertAvailabilities(1, CourseStreamAvailability.Mandatory);
            AdjustAssertAvailabilities(2, CourseStreamAvailability.Optional);
            AdjustAssertAvailabilities(3, CourseStreamAvailability.Optional);
            AdjustAssertAvailabilities(1, CourseStreamAvailability.Optional);
            AdjustAssertAvailabilities(1, CourseStreamAvailability.None);
            AdjustAssertAvailabilities(streams - 1, CourseStreamAvailability.Mandatory);

            void AdjustAssertAvailabilities(int index, CourseStreamAvailability availability)
            {
                AdjustAvailability(index, availability);
                AssertAvailabilities();
            }
            void AdjustAvailability(int index, CourseStreamAvailability availability)
            {
                currentAvailabilities[index] = availabilitiesStruct[index] = availability;
            }
            void AssertAvailabilities()
            {
                for (int i = 0; i < streams; i++)
                    Assert.AreEqual(currentAvailabilities[i], availabilitiesStruct[i]);
            }
        }

        [Test]
        public void ToStringTest()
        {
            var availabilitiesStruct = new AvailableCourseStreams();

            Assert.AreEqual("None", availabilitiesStruct.ToString());

            availabilitiesStruct[1] = CourseStreamAvailability.Mandatory;
            availabilitiesStruct[3] = CourseStreamAvailability.Mandatory;
            availabilitiesStruct[8] = CourseStreamAvailability.Optional;

            Assert.AreEqual("1 - Mandatory, 3 - Mandatory, 8 - Optional", availabilitiesStruct.ToString());
        }
    }
}