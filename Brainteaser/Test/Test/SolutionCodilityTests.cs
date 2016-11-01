using System;
using NUnit.Framework;

namespace TapeEquilibrium
{
    [TestFixture]
    internal sealed class SolutionCodilityTests
    {
        private SolutionCodility m_Solution;
        private int[] m_Numbers;

        [SetUp]
        public void Setup()
        {
            m_Numbers = new[] {3, 1, 2, 4, 3};

            m_Solution = new SolutionCodility();
        }

        [Test]
        public void SplitSumAtZeroTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, 0);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void SplitSumAtNegativeTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, -1);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void SplitSumAtLengthTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, m_Numbers.Length);

            Assert.AreEqual(-1, actual);
        }

        [Test]
        public void SplitSumAtOneTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, 1);

            Assert.AreEqual(7, actual);
        }

        [Test]
        public void SplitSumAtTwoTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, 2);

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void SplitSumAtThreeTest()
        {
            var actual = m_Solution.SplitSum(m_Numbers, 3);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseOneTest()
        {
            var actual = m_Solution.Solution(m_Numbers);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseTwoTest()
        {
            var actual = m_Solution.Solution(new[] {1, 2, 3});

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void CaseFourTest()
        {
            var actual = m_Solution.Solution(new[] { 1, 2, 3, 4 });

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void CaseFiveTest()
        {
            var actual = m_Solution.Solution(new[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(3, actual);
        }

        [Test]
        public void CaseSixTest()
        {
            var actual = m_Solution.Solution(new[] {1, 2});

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseBigTest()
        {
            var number = CreateBigNumbers(10000);

            var start = DateTime.Now;

            m_Solution.Solution(number);

            var end = DateTime.Now;

            var timeSpan = end - start;

            Assert.True(6.0 > timeSpan.Seconds, "Expired Time: " + timeSpan.Seconds + "s");
        }

        private int[] CreateBigNumbers(int size)
        {
            Random random = new Randomizer(0);

            int[] numbers = new int[size];

            for(int i=0; i<numbers.Length; i++)
            {
                numbers[i] = random.Next(-1000, 1000);
            }

            return numbers;
        }
    }
}