using System;
using System.Collections.Generic;
using System.Text;

namespace CourseStreamSelection.Model
{
    public struct AvailableCourseStreams : IEquatable<AvailableCourseStreams>
    {
        private uint bits;

        public List<int> MandatoryIndices => GetIndices(CourseStreamAvailability.Mandatory);
        public List<int> OptionalIndices => GetIndices(CourseStreamAvailability.Optional);

        private List<int> GetIndices(CourseStreamAvailability availability)
        {
            var result = new List<int>(9);
            for (int i = 0; i < 9; i++)
                if (this[i] == availability)
                    result.Add(i);
            return result;
        }

        // What the fuck is this and why did it work the first time
        // Would be a good thing if I made an abstracted version of this
        public CourseStreamAvailability this[int index]
        {
            get => (CourseStreamAvailability)((bits >> (index * 2)) & 0b11);
            set => bits = (bits & (~(0b11u << (index * 2)))) | ((uint)value << (index * 2));
        }

        public static bool operator ==(AvailableCourseStreams left, AvailableCourseStreams right) => left.Equals(right);
        public static bool operator !=(AvailableCourseStreams left, AvailableCourseStreams right) => !(left == right);

        public bool Equals(AvailableCourseStreams other) => bits == other.bits;

        public override int GetHashCode() => bits.GetHashCode();
        public override bool Equals(object obj) => obj is AvailableCourseStreams c && Equals(c);
        public override string ToString()
        {
            // This is clearly not a performant way to do it but who cares
            if (bits == 0)
                return "None";

            var result = new StringBuilder();
            for (int i = 0; i < sizeof(uint) * 8 / 2; i++)
            {
                var availability = this[i];
                if (availability == CourseStreamAvailability.None)
                    continue;

                result.Append($"{i} - {availability}, ");
            }

            return result.Remove(result.Length - 2, 2).ToString();
        }
    }
}