using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Game.Tests
{
    public class TestHelper
    {
        public static void AssertArray(IEnumerable <int> expected,
                                       IEnumerable <int> actual)
        {
            int[] èxpectedArray = expected.ToArray();
            int[] actualArray = actual.ToArray();

            string message = string.Format("expected is {0} but actual is {1}!",
                                           ArrayToString(èxpectedArray),
                                           ArrayToString(actualArray));

            Assert.True(èxpectedArray.SequenceEqual(actualArray),
                        message);
        }

        public static string ArrayToString(IEnumerable <int> array)
        {
            return string.Join(",",
                               array);
        }
    }
}