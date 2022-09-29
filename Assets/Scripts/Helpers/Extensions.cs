using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public static class Extensions
    {
        public static float PerformanceDistance(Vector3 a, Vector3 b)
        {
            var distance = (a - b).sqrMagnitude;

            return Mathf.Sqrt(distance);
        }
    }

    public static class EnumerableHelper<E>
    {
        private static System.Random r;

        static EnumerableHelper()
        {
            r = new System.Random();
        }

        public static T Random<T>(IEnumerable<T> input)
        {
            return input.ElementAt(r.Next(input.Count()));
        }
    }

    public static class EnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> input)
        {
            return EnumerableHelper<T>.Random(input);
        }
    }
}
