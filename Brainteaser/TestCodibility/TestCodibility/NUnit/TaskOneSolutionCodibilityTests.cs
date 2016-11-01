using NUnit.Framework;

namespace TestCodibility.NUnit
{
    [TestFixture]
    internal sealed class TaskOneSolutionCodibilityTests
    {
        private TaskOneSolutionCodibility m_TaskOneSolution;

        [SetUp]
        public void Setup()
        {
            m_TaskOneSolution = new TaskOneSolutionCodibility();
        }

        [Test]
        public void ExampleTest()
        {
            const int expected = 14;
            var actual = m_TaskOneSolution.solution(5, 3, -1, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleTwoTest()
        {
            var array = new[] {5, -1, 5, 3};

            const int expected = 14;
            var actual = m_TaskOneSolution.solution(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllSamePositiveTest()
        {
            var array = new[] { 1, 1, 1, 1 };

            const int expected = 0;
            var actual = m_TaskOneSolution.solution(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllSameNegativeTest()
        {
            var array = new[] { -1, -1, -1, -1 };

            const int expected = 0;
            var actual = m_TaskOneSolution.solution(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllSamePositveNegativeTest()
        {
            var array = new[] { -1, -1, 1, 1 };

            const int expected = 6;
            var actual = m_TaskOneSolution.solution(array);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AllSameBigNegativeTest()
        {
            var array = new[] { -1000000, -1000000, -1000000, -1000000 };

            const int expected = 0;
            var actual = m_TaskOneSolution.solution(array);

            Assert.AreEqual(expected, actual);
        }
    }
}