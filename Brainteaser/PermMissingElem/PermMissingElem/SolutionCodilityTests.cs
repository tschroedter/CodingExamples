using System;
using NUnit.Framework;

namespace PermMissingElem
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

        [Test]
        public void CaseOneTest()
        {
            var actual = m_Solution.Solution(new[] { 2, 3, 1, 5 });

            Assert.AreEqual(4, actual);
        }

        [Test]
        public void CaseTwoTest()
        {
            var actual = m_Solution.Solution(new[] { 2, 3, 1, 4 });

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void CaseThreeTest()
        {
            var actual = m_Solution.Solution(new[] { 2, 3, 5, 4 });

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void CaseBigTest()
        {
            var numbers = CreateNumbers(100000);

            var start = DateTime.Now;

            var actual = m_Solution.Solution(numbers);

            var end = DateTime.Now;

            var seconds = (end - start).Seconds;

            Assert.AreEqual(100001, actual, "Missing Number");
            Assert.True(seconds < 6, "Expired Time: " + seconds + "s");
        }

        private int[] CreateNumbers(int size)
        {
            int[] numbers = new int[size];

            for(int i=0; i<size; i++)
            {
                numbers[i] = i + 1;
            }

            return numbers;
        }
    }
}