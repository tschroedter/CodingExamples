using NUnit.Framework;

namespace FrogJump.NUnit
{
    [TestFixture]
    public class SolutionTests
    {
        [SetUp]
        public void Setup()
        {
            m_TestSolution = new TestSolution();
        }

        private TestSolution m_TestSolution;

        [Test]
        public void CaseFiveTest()
        {
            const int expected = 3;
            int actual = m_TestSolution.Solution(-100, -10, 30);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseFourTest()
        {
            const int expected = 1;
            int actual = m_TestSolution.Solution(0, 10, 30);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseOneTest()
        {
            const int expected = 3;
            int actual = m_TestSolution.Solution(10, 85, 30);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseSeventTest()
        {
            const int expected = 0;
            int actual = m_TestSolution.Solution(-100, 100, -30);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseSixTest()
        {
            const int expected = 7;
            int actual = m_TestSolution.Solution(-100, 100, 30);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseThreeTest()
        {
            const int expected = 0;
            int actual = m_TestSolution.Solution(10, 10, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CaseTwoTest()
        {
            const int expected = 0;
            int actual = m_TestSolution.Solution(10, 10, 30);

            Assert.AreEqual(expected, actual);
        }
    }
}