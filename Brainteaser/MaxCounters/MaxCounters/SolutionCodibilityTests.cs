using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MaxCounters
{
    [TestFixture]
    internal sealed class SolutionCodibilityTests
    {
        private SolutionCodibility m_Solution;
        private int[] m_A;

        [SetUp]
        public void Setup()
        {
            m_A = new[] { 3, 4, 4, 6, 1, 4, 4 };

            m_Solution = new SolutionCodibility();
        }

        [Test]
        public void CaseOneTest()
        {
            var expected = new[] {3, 2, 2, 4, 2};
            var actual = m_Solution.solution(5, m_A);

            var message = string.Format("\n\nExpected:\t{0}\nActual:\t\t{1}",
                                        ArrayToString(expected),
                                        ArrayToString(actual));

            Assert.True(expected.SequenceEqual(actual), message);
        }

        private string ArrayToString(int[] array)
        {
            StringBuilder builder = new StringBuilder();

            foreach (int number in array)
            {
                builder.Append(" " + number);
            }

            return builder.ToString();
        }
    }
}