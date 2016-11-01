using DSim.Common;
using DSim.LogicGates;
using NSubstitute;
using NUnit.Framework;

namespace DSim.Tests.LogicGates
{
    [TestFixture]
    internal sealed class OrTests
    {
        [SetUp]
        public void Setup()
        {
            m_WireInOne = Substitute.For <IWire>();
            m_WireInTwo = Substitute.For <IWire>();
            m_WireOut = Substitute.For <IWire>();

            m_Sut = new Or(m_WireInOne,
                           m_WireInTwo,
                           m_WireOut);
        }

        private const int TimeDoesNotMatter = 0;
        private IWire m_WireInOne;
        private IWire m_WireInTwo;
        private IWire m_WireOut;
        private Or m_Sut;

        [Test]
        [TestCase(false, false, false)]
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(true, true, true)]
        public void FunctionUnderTest_ExpectedResult_UnderCondition(bool inputOne,
                                                                    bool inputTwo,
                                                                    bool expected)
        {
            // Arrange
            m_WireInOne.GetSignal().Returns(inputOne);
            m_WireInTwo.GetSignal().Returns(inputTwo);

            // Act
            m_Sut.Calculate(0);

            // Assert
            m_WireOut.Received().SetSignal(TimeDoesNotMatter,
                                           expected);
        }
    }
}