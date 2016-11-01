using NUnit.Framework;

namespace MissingInteger
{
    [TestFixture]
    internal sealed class SolutionCodibilityTests
    {
        private SolutionCodibility m_Solution;

        [SetUp]
        public void SetUp()
        {
            m_Solution = new SolutionCodibility();
        }

        [Test]
        public void CaseTest()
        {
            var numbers = new[] { 1, 3, 6, 4, 1, 2 };

            const int expected = 5;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseTwoTest()
        {
            var numbers = new[] { 1 };

            const int expected = 2;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseThreeTest()
        {
            var numbers = new[] { 0 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseFourTest()
        {
            var numbers = new[] { -1 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case6Test()
        {
            var numbers = new[] { -1, 0, 2 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case7Test()
        {
            var numbers = new[] { -1, 0, 3, 2 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case8Test()
        {
            var numbers = new[] { -1, -3, -4 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case9Test()
        {
            var numbers = new[] { int.MinValue };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case10Test()
        {
            var numbers = new[] { int.MinValue, int.MaxValue };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case11Test()
        {
            var numbers = new[] { int.MinValue, 100, -100, -50, -1000, 102 };

            const int expected = 101;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case12Test()
        {
            var numbers = CreateBig(10000);

            const int expected = 10001;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case13Test()
        {
            var numbers = new[] {0, 2};

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Case14Test()
        {
            var numbers = new[] { -1, 0, 2 };

            const int expected = 1;
            var actual = m_Solution.solution(numbers);

            Assert.AreEqual(expected, actual);
        }

        private int[] CreateBig(int size)
        {
            var numbers = new int[size];

            for(int i=0; i<size; i++)
            {
                numbers[i] = i + 1;
            }

            return numbers;
        }
    }
}