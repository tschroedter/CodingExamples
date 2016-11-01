using NUnit.Framework;

namespace PassingCars
{
    [TestFixture]
    internal sealed class SolutionCodibiltyTests
    {
        private SolutionCodibilty m_Solution;

        [SetUp]
        public void Setup()
        {
            m_Solution = new SolutionCodibilty();
        }

        [Test]
        public void CaseOneTest()
        {
            var eastWest = new [] {0, 1, 0, 1, 1};

            const int expected = 5;
            var actual = m_Solution.Solution(eastWest);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseTwoTest()
        {
            var eastWest = new[] { 1, 1, 1, 1, 1 };

            const int expected = 0;
            var actual = m_Solution.Solution(eastWest);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void CaseThreeTest()
        {
            var eastWest = new[] { 0, 0, 0, 0, 0 };

            const int expected = 0;
            var actual = m_Solution.Solution(eastWest);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseFourTest()
        {
            var eastWest = new[] { 0, 1, 1, 1, 1 };

            const int expected = 4;
            var actual = m_Solution.Solution(eastWest);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseFiveTest()
        {
            var eastWest = new[] { 1, 0, 0, 0, 0 };

            const int expected = 4;
            var actual = m_Solution.Solution(eastWest);

            Assert.AreEqual(expected, actual);
        }
    }

    [TestFixture]
    internal sealed class PassingCarsTests
    {
        private int[] m_EastWest;
        private CarPair m_CarPair;
        private CarPair m_CarPairSwapped;
        private CarPair m_CarPairOther;

        [SetUp]
        public void Setup()
        {
            m_EastWest = new[] { 0, 1, 0, 1, 1 };

            m_CarPair = new CarPair(m_EastWest,
                                            0,
                                            1);

            m_CarPairSwapped = new CarPair(m_EastWest,
                                                   1,
                                                   0);

            m_CarPairOther = new CarPair(m_EastWest,
                                                 2,
                                                 3);
        }

        [Test]
        public void DefaultCarOneTest()
        {
            Assert.AreEqual(0, m_CarPair.CarOne);
        }

        [Test]
        public void DefaultCarTwoTest()
        {
            Assert.AreEqual(1, m_CarPair.CarTwo);
        }

        [Test]
        public void DefaultIsValidTest()
        {
            Assert.True(m_CarPair.IsValid);
        }

        [Test]
        public void NonPassingCarsIsValidReturnsFalseTest()
        {
            var passingCars = new CarPair(m_EastWest, 0, 2);

            Assert.False(passingCars.IsValid);
        }

        [Test]
        public void SameCarIsValidReturnsFalseTest()
        {
            var passingCars = new CarPair(m_EastWest, 2, 2);

            Assert.False(passingCars.IsValid);
        }

        [Test]
        public void EqualsForSameReturnsTrueTest()
        {
            // ReSharper disable EqualExpressionComparison
            Assert.True(m_CarPair.Equals(m_CarPair));
            // ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsForSameSwappedReturnsTrueTest()
        {
            Assert.True(m_CarPair.Equals(m_CarPairSwapped));
        }

        [Test]
        public void EqualsForOtherdReturnsFalseTest()
        {
            Assert.False(m_CarPair.Equals(m_CarPairOther));
        }

        [Test]
        public void ThreeOneReturnsFalseTest()
        {
            var passingCars = new CarPair(m_EastWest,
                                              3,
                                              1);

            Assert.False(passingCars.IsValid);
        }

        [Test]
        public void OneThreeReturnsFalseTest()
        {
            var passingCars = new CarPair(m_EastWest,
                                              1,
                                              3);

            Assert.False(passingCars.IsValid);
        }
    }
}