using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Importers;
using Evaluation.Interfaces.Shapes;
using NSubstitute;
using NUnit.Framework;

namespace Evaluation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class ClosestPointsFinderTests
    {
        [SetUp]
        public void Setup()
        {
            m_ShiftByVector = new Point3D(DoesNotMatter,
                                          1.0,
                                          1.0,
                                          1.0,
                                          "Shift By Vector");

            m_Arguments = new ApplicationArguments
                          {
                              Source = "Source",
                              NumberOfClosestPoints = 1,
                              QueryPointCoordinates = "-1.0 2.0 -3.0",
                              ShiftPointCoordinates = "-11.0 22.0 -33.0",
                              Verbose = true
                          };

            m_Loader = Substitute.For <ICsvIntoRepositoryLoader>();
            m_Manager = Substitute.For <IPointsManager>();
            m_Calculator = Substitute.For <IPointToPointsCalculator>();
            m_Displayer = Substitute.For <IDisplayApplicationArguments>();

            m_Sut = new ClosestPointsFinder(m_Loader,
                                            m_Manager,
                                            m_Calculator,
                                            m_Displayer);
        }

        private const int DoesNotMatter = -1;
        private ApplicationArguments m_Arguments;
        private ICsvIntoRepositoryLoader m_Loader;
        private IPointsManager m_Manager;
        private IPointToPointsCalculator m_Calculator;
        private IDisplayApplicationArguments m_Displayer;
        private ClosestPointsFinder m_Sut;
        private Point3D m_ShiftByVector;

        [Test]
        public void ClosestIds_IsNotNull_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.NotNull(m_Sut.ClosestIds);
        }

        [Test]
        public void Run_CallsDisplay_ForVerboseIsTrue()
        {
            // Arrange
            m_Arguments.Verbose = true;

            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            m_Displayer.Received().Display(m_Arguments);
        }

        [Test]
        [Combinatorial]
        public void Run_CallShift_ForVectorNotAllCoordinatesZero(
            [Values("-1.0", "0.0", "1.0")] string x,
            [Values("-1.0", "0.0", "1.0")] string y,
            [Values("-1.0", "0.0", "1.0")] string z)
        {
            // Arrange
            m_Arguments.ShiftPointCoordinates =
                string.Format("{0} {1} {2}",
                              x,
                              y,
                              z);

            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            if ( x == "0.0" &&
                 y == "0.0" &&
                 z == "0.0" )
            {
                m_Manager.DidNotReceive().Shift(Arg.Any <IPoint3D>());
            }
            else
            {
                m_Manager.Received().Shift(Arg.Any <IPoint3D>());
            }
        }

        [Test]
        public void Run_CallsLoadFromCsvFile_ForVerboseIsTrue()
        {
            // Arrange
            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            m_Loader.Received().LoadFromCsvFile(m_Arguments.Source);
        }

        [Test]
        public void Run_CallsShiftWithCorrectVector_ForShiftVectorNotAllZero()
        {
            // Arrange
            var arguments = Substitute.For <IApplicationArguments>();
            arguments.GetShiftVector3D().Returns(m_ShiftByVector);

            // Act
            m_Sut.Run(arguments);

            // Assert
            m_Manager.Received().Shift(m_ShiftByVector);
        }

        [Test]
        public void Run_DoesNotCallsDisplay_ForVerboseIsFalse()
        {
            // Arrange
            m_Arguments.Verbose = false;

            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            m_Displayer.DidNotReceive().Display(m_Arguments);
        }

        [Test]
        public void Run_DoesNotCallShift_ForShiftVectorIsAllZero()
        {
            // Arrange
            m_Arguments.ShiftPointCoordinates = "0.0 0.0 0.0";

            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            m_Manager.DidNotReceive().Shift(Arg.Any <IPoint3D>());
        }

        [Test]
        public void Run_FindsClosestIds_WhenCalled()
        {
            // Arrange
            var expected = new[]
                           {
                               1
                           };

            m_Calculator.Ids().Returns(new[]
                                       {
                                           1,
                                           2,
                                           3
                                       });

            // Act
            m_Sut.Run(m_Arguments);

            // Assert
            NUnitHelper.AssertIntegers(expected,
                                       m_Sut.ClosestIds);
        }
    }
}