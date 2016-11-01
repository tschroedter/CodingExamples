using NUnit.Framework;

namespace TestCodibility.NUnit
{
    [TestFixture]
    internal sealed class Task2SolutionCodibilityTests
    {
        private Task2SolutionCodibility m_Solution;

        [SetUp]
        public void Setup()
        {
            m_Solution = new Task2SolutionCodibility();
        }

        [Test]
        public void ExampleTest()
        {
            const int expected = 3;
            var actual = m_Solution.solution(1410);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleNegativeTest()
        {
            const int expected = 3;
            var actual = m_Solution.solution(-1410);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleZeroTest()
        {
            const int expected = 1;
            var actual = m_Solution.solution(0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleBigNegativeTest()
        {
            const int expected = 7;
            var actual = m_Solution.solution(-2147483648);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleBigPositiveTest()
        {
            const int expected = 7;
            var actual = m_Solution.solution(2147483647);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleMinTest()
        {
            const int expected = 7;
            var actual = m_Solution.solution(int.MinValue);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExampleMaxTest()
        {
            const int expected = 7;
            var actual = m_Solution.solution(int.MaxValue);

            Assert.AreEqual(expected, actual);
        }

    }
}