using System;
using System.Linq;
using NUnit.Framework;

namespace InterviewZen.NUint
{
    [TestFixture]
    internal sealed class DistinctPairsFinderTests
    {
        [SetUp]
        public void Setup()
        {
            m_Numbers = new[] {1, 2, 3, 4, 2};

            m_Finder = new DistinctPairsFinder(m_Numbers);
        }

        private DistinctPairsFinder m_Finder;
        private int[] m_Numbers;

        [Ignore]
        public void TimeTest()
        {
            int[] numbers = CreateNumbers(200);
            var finder = new DistinctPairsFinder(numbers);

            DateTime start = DateTime.Now;

            finder.Find();

            DateTime end = DateTime.Now;

            var expected = new TimeSpan(0, 0, 1);
            TimeSpan actual = end - start;

            Assert.AreEqual(expected, actual);
        }

        private int[] CreateNumbers(int length)
        {
            var numbers = new int[length];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            return numbers;
        }

        [Test]
        public void FindCountTest()
        {
            m_Finder.Find();

            OddPair[] actual = m_Finder.OddPairs;

            Assert.AreEqual(4, actual.Length);
        }

        [Test]
        public void FindFirstOddPairTest()
        {
            m_Finder.Find();

            var expected = new OddPair(1, 2);
            OddPair actual = m_Finder.OddPairs.First(x => x.Equals(expected));

            Assert.NotNull(actual);
        }

        [Test]
        public void FindSecondFourthPairTest()
        {
            m_Finder.Find();

            var expected = new OddPair(2, 3);
            OddPair actual = m_Finder.OddPairs.First(x => x.Equals(expected));

            Assert.NotNull(actual);
        }

        [Test]
        public void FindSecondOddPairTest()
        {
            m_Finder.Find();

            var expected = new OddPair(1, 4);
            OddPair actual = m_Finder.OddPairs.First(x => x.Equals(expected));

            Assert.NotNull(actual);
        }

        [Test]
        public void FindSecondThirdPairTest()
        {
            m_Finder.Find();

            var expected = new OddPair(3, 4);
            OddPair actual = m_Finder.OddPairs.First(x => x.Equals(expected));

            Assert.NotNull(actual);
        }
    }
}