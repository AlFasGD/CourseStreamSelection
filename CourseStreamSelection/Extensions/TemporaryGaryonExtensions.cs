using System.Collections.Generic;
using System.Linq;

namespace CourseStreamSelection.Extensions
{
    /// <summary>
    /// Contains tepmorarily added Garyon extensions until the package becomes available for consumption.<br/>
    /// This class is only intended to contain the least possible functions that satisfy the contained code of this program.<br/>
    /// Extensions irrelevant to Garyon, which are extensions that should not be available for general usage purposes, should be added to other classes.<br/>
    /// This class' extensions should not contain any documentation. The functions themselves within Garyon should be well-documented.
    /// </summary>
    public static class TemporaryGaryonExtensions
    {
        public static void AddRange<T>(this ICollection<T> c, params T[] elements) => AddRange(c, (IEnumerable<T>)elements);
        public static void AddRange<T>(this ICollection<T> c, IEnumerable<T> elements)
        {
            foreach (var e in elements)
                c.Add(e);
        }

        public static T[] CopyArray<T>(this T[] ar)
        {
            var result = new T[ar.Length];
            for (int i = 0; i < ar.Length; i++)
                result[i] = ar[i];
            return result;
        }

        public static bool IsDigit(this char c) => char.IsDigit(c);

        public static string RemoveLastNumber(this string s)
        {
            int i = s.Length;
            while (i > 0 && s[i - 1].IsDigit())
                i--;
            return s.Substring(0, i);
        }
        public static string RemoveLastNumber(this string s, out int removedNumber)
        {
            int i = s.Length;
            while (i > 0 && s[i - 1].IsDigit())
                i--;

            if (i < s.Length)
                removedNumber = int.Parse(s.Substring(i));
            else
                removedNumber = 0;

            return s.Substring(0, i);
        }

        public static double[] Normalize(this double[] ar)
        {
            var result = new double[ar.Length];
            var min = ar.Min();
            var max = ar.Max();

            if (min != max)
                for (int i = 0; i < result.Length; i++)
                    result[i] = (ar[i] - min) / (max - min);
            else
                for (int i = 0; i < result.Length; i++)
                    result[i] = 1;

            return result;
        }
        public static double[] NormalizeUpper(this double[] ar)
        {
            var result = new double[ar.Length];
            var max = ar.Max();

            for (int i = 0; i < result.Length; i++)
                result[i] = ar[i] / max;

            return result;
        }
        public static double[] NormalizeLower(this double[] ar)
        {
            var result = new double[ar.Length];
            var min = ar.Min();

            for (int i = 0; i < result.Length; i++)
                result[i] = ar[i] - min;

            return result;
        }
        public static Dictionary<T, double> Normalize<T>(this Dictionary<T, double> d)
        {
            var result = new Dictionary<T, double>();
            var min = d.Values.Min();
            var max = d.Values.Max();

            if (min != max)
                foreach (var kvp in d)
                    result.Add(kvp.Key, (kvp.Value - min) / (max - min));
            else
                foreach (var kvp in d)
                    result.Add(kvp.Key, 1);

            return result;
        }
        public static Dictionary<T, double?> Normalize<T>(this Dictionary<T, double?> d)
        {
            return d.ToNonNullableValueDictionary().Normalize().ToNullableValueDictionary();
        }

        public static Dictionary<TKey, TNonNullable> ToNonNullableValueDictionary<TKey, TNonNullable>(this Dictionary<TKey, TNonNullable?> d)
            where TNonNullable : struct
        {
            return d.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Value);
        }
        public static Dictionary<TKey, TNonNullable?> ToNullableValueDictionary<TKey, TNonNullable>(this Dictionary<TKey, TNonNullable> d)
            where TNonNullable : struct
        {
            return d.ToDictionary(kvp => kvp.Key, kvp => (TNonNullable?)kvp.Value);
        }
    }
}
