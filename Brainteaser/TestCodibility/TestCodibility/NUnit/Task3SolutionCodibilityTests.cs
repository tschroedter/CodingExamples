using NUnit.Framework;

namespace TestCodibility.NUnit
{
    [TestFixture]
    internal sealed class Task3SolutionCodibilityTests
    {
        private Task3SolutionCodibility m_Solution;

        [SetUp]
        public void Setup()
        {
            m_Solution = new Task3SolutionCodibility();
        }

        [Test]
        public void ExampleTest()
        {
            var numbers = new[] { 3, 5, 6, 3, 3, 5 };

            const int expected = 4;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }
    }
}