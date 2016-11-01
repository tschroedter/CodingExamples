using System;
using System.Linq;
using NUnit.Framework;

namespace FrogRiverOne
{
    [TestFixture]
    internal sealed class SolutionCodilityTests
    {
        private SolutionCodility m_Solution;

        [SetUp]
        public void Setup()
        {
            m_Solution = new SolutionCodility();
        }

//        [Test]
//        public void CodilityTest()
//        {
//            var minutes = new[] {1, 3, 1, 4, 2, 3, 5, 4};
//
//            var actual = m_Solution.Solution(5, minutes);
//
//            Assert.AreEqual(5, actual);
//        }

        [Test]
        public void CodilityTest()
        {
            var minutes = new[] {1, 3, 1, 4, 2, 3, 5, 4};

            var actual = m_Solution.Solution(5, minutes);

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void CaseAllSameOneTest()
        {
            var minutes = new[] { 1, 1, 1 };

            var actual = m_Solution.Solution(2, minutes);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseOneElementOneTest()
        {
            var minutes = new[] { 1 };

            var actual = m_Solution.Solution(0, minutes);

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseOneElementMaxTest()
        {
            var minutes = new[] { 100000 };

            var actual = m_Solution.Solution(0, minutes);

            Assert.AreEqual(100000, actual);
        }
        
        /*
        [Test]
        public void CaseAllSameMaxTest()
        {
            var minutes = new[] { 100000, 100000, 100000 };

            var actual = m_Solution.Solution(1, minutes);

            Assert.AreEqual(100001, actual);
        }

        [Test]
        public void CaseMinAverageMaxFirstTest()
        {
            var minutes = new[] { 1, 50000, 100000 };

            var actual = m_Solution.Solution(1, minutes);

            Assert.AreEqual(50001, actual);
        }

        [Test]
        public void CaseMinAverageMaxMiddleTest()
        {
            var minutes = new[] { 1, 50000, 100000 };

            var actual = m_Solution.Solution(1, minutes);

            Assert.AreEqual(50001, actual);
        }

        [Test]
        public void CaseMinAverageMaxLastTest()
        {
            var minutes = new[] { 1, 50000, 100000 };

            var actual = m_Solution.Solution(2, minutes);

            Assert.AreEqual(100001, actual);
        }

        [Test]
        public void BigCaseAllTheSameTest()
        {
            var minutes = CreateAllTheSame(100000, 50000);

            var start = DateTime.Now;

            var actual = m_Solution.Solution(2, minutes);

            var end = DateTime.Now;

            var seconds = (end - start).Seconds;

            Assert.AreEqual(50001, actual);
            Assert.True(seconds < 2, "Expired Time: " + seconds + "s");

        }

        private int[] CreateAllTheSame(int size, int value)
        {
            var minutes = Enumerable.Repeat(value, size).ToArray();

            return minutes;
        }
         */
    }
}