using System;
using NUnit.Framework;

namespace PermCheck
{
    [TestFixture]
    internal sealed class SolutionCodilityTests
    {
        [SetUp]
        public void Setup()
        {
            m_Solution = new SolutionCodility();
        }

        private SolutionCodility m_Solution;

        private int[] CreateNumbersMissingOne(int size)
        {
            var numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                if (i == size - 1)
                {
                    numbers[i] = i + 2;
                }
                else
                {
                    numbers[i] = i + 1;
                }
            }

            return numbers;
        }

        private int[] CreateNumbers(int size)
        {
            var numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = i + 1;
            }

            return numbers;
        }

        [Test]
        public void CaseBigMissingTest()
        {
            int[] numbers = CreateNumbersMissingOne(10000);

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseBigTest()
        {
            int[] numbers = CreateNumbers(10000);

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseFiveReturnsFalseTest()
        {
            var numbers = new[] {1000, 1};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseFourReturnsFalseTest()
        {
            var numbers = new[] {3, 1};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseOneElementReturnsFalseTest()
        {
            var numbers = new[] {2};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseOneReturnsTrueTest()
        {
            var numbers = new[] {4, 1, 3, 2};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseThreeReturnsTrueTest()
        {
            var numbers = new[] {2, 1};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseTimeTest()
        {
            int[] numbers = CreateNumbers(100000);

            DateTime start = DateTime.Now;

            int actual = m_Solution.Solution(numbers);

            DateTime end = DateTime.Now;

            int seconds = (end - start).Seconds;

            Assert.AreEqual(1, actual, "Missing Number");
            Assert.True(seconds < 2, "Expired Time: " + seconds + "s");
        }

        [Test]
        public void CaseTwoReturnsFalseTest()
        {
            var numbers = new[] {4, 1, 3};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseAllSameReturnsFalseTest()
        {
            var numbers = new[] { 1, 1, 1 };

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseDuplicateReturnsFalseTest()
        {
            var numbers = new[] { 1, 1, 3 };

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void OneElementMaxValueTest()
        {
            var numbers = new[] {int.MaxValue};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void OneElementMinValueTest()
        {
            var numbers = new[] {int.MinValue};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void OneElementWithOneReturnsTrueTest()
        {
            var numbers = new[] {1};

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void RandomNumbersTest()
        {
            var numbers = new[] { 10000, 10, 22 };

            int actual = m_Solution.Solution(numbers);

            Assert.AreEqual(0, actual);
        }
    }
}