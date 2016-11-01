using NUnit.Framework;

namespace InterviewZen.NUint
{
    [TestFixture]
    internal sealed class OddPairTests
    {
        [SetUp]
        public void Setup()
        {
            m_PairOne = new OddPair(1, 2);
            m_PairTwo = new OddPair(2, 5);
            m_PairOneSwapped = new OddPair(2, 1);
        }

        private OddPair m_PairOne;
        private OddPair m_PairTwo;
        private OddPair m_PairOneSwapped;

        [Test]
        public void DefaultFirstTest()
        {
            Assert.AreEqual(1, m_PairOne.First);
        }

        [Test]
        public void DefaultSecondTest()
        {
            Assert.AreEqual(2, m_PairOne.Second);
        }

        [Test]
        public void EqualsReturnsFalseForDifferentTest()
        {
            Assert.False(m_PairOne.Equals(m_PairTwo));
        }

        [Test]
        public void EqualsReturnsTrueForSameTest()
        {
            Assert.True(m_PairOne.Equals(m_PairOne));
        }

        [Test]
        public void EqualsReturnsTrueForSameValuesSwappedTest()
        {
            Assert.True(m_PairOne.Equals(m_PairOneSwapped));
        }

        [Test]
        public void GetHashCodeTest()
        {
            const int expected = 399;
            int actual = m_PairOne.GetHashCode();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToStringTest()
        {
            const string expected = "[1,2]";
            string actual = m_PairOne.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}