using NUnit.Framework;

namespace TestCodibility.NUnit
{
    [TestFixture]
    internal class Task4SolutionCodibilityTests
    {
        [SetUp]
        public void Setup()
        {
            m_Solution = new Task4SolutionCodibility();
        }

        private Task4SolutionCodibility m_Solution;

        [Test]
        public void ExampleTest()
        {
            var numbers = new[] {10, 2, 5, 1, 8, 20};

            const int expected = 23;
            int actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleThreeTest()
        {
            var numbers = new[] {10, 20, 30};

            const int expected = -1;
            int actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleTwoTest()
        {
            var numbers = new[] {5, 10, 18, 7, 8, 3};

            const int expected = 25;
            int actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }
    }
}