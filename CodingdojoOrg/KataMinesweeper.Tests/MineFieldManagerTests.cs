using System.Diagnostics.CodeAnalysis;
using KataMinesweeper.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace KataMinesweeper.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class MineFieldManagerTests
    {
        [SetUp]
        public void Setup()
        {
            m_Converter = Substitute.For <IStringToMineFieldConverter>();
            m_MineField = Substitute.For <IMineField>();
            m_MineLayer = Substitute.For <IMineLayer>();
            m_HintField = Substitute.For <IHintField>();
            m_PlayingField = Substitute.For <IPlayingField>();
            m_UserOutput = Substitute.For <IUserOutput>();

            m_MineFieldFactory = Substitute.For <IMineFieldFactory>();
            m_MineLayerFactory = Substitute.For <IMineLayerFactory>();
            m_HintFieldFactory = Substitute.For <IHintFieldFactory>();
            m_PlayingFieldFactory = Substitute.For <IPlayingFieldFactory>();
            m_UserInptut = Substitute.For <IUserInput>();
            m_UserOutputFactory = Substitute.For <IUserOutputFactory>();

            m_MineFieldFactory.Create(Arg.Any <int>(),
                                      Arg.Any <int>()).Returns(m_MineField);
            m_MineLayerFactory.Create(Arg.Any <IMineField>()).Returns(m_MineLayer);
            m_HintFieldFactory.Create(Arg.Any <IMineField>()).Returns(m_HintField);
            m_PlayingFieldFactory.Create(Arg.Any <IMineField>()).Returns(m_PlayingField);
            m_UserOutputFactory.Create(Arg.Any <IHintField>(),
                                       Arg.Any <IPlayingField>()).Returns(m_UserOutput);
        }

        private IMineLayerFactory m_MineLayerFactory;
        private IHintFieldFactory m_HintFieldFactory;
        private IPlayingFieldFactory m_PlayingFieldFactory;
        private IUserInput m_UserInptut;
        private IUserOutputFactory m_UserOutputFactory;
        private IMineLayer m_MineLayer;
        private IHintField m_HintField;
        private IPlayingField m_PlayingField;
        private IUserOutput m_UserOutput;
        private IMineField m_MineField;
        private IMineFieldFactory m_MineFieldFactory;
        private IStringToMineFieldConverter m_Converter;

        private MineFieldManager CreateSut()
        {
            // todo remove long list of dependencies
            var sut = new MineFieldManager(m_Converter,
                                           m_MineFieldFactory,
                                           m_MineLayerFactory,
                                           m_HintFieldFactory,
                                           m_PlayingFieldFactory,
                                           m_UserInptut,
                                           m_UserOutputFactory);

            return sut;
        }

        [Test]
        public void AskUserForRowAndCoumn_CallsUserInput_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.AskUserForRowAndCoumn(1,
                                      2);

            // Assert
            m_UserInptut.Received().AskUserForRowAndCoumn(1,
                                                          2);
        }

        [Test]
        public void CreateMineField_CallsConverter_ForGivenText()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField("Doesn't matter!");

            // Assert
            m_Converter.Received().ToMineField("Doesn't matter!");
        }

        [Test]
        public void CreateMineField_CallsCreateCommon_ForGivenText()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField("Doesn't matter!");

            // Assert
            m_HintFieldFactory.Received().Create(Arg.Any <IMineField>());
        }

        [Test]
        public void CreateMineField_CreatesHintField_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_HintFieldFactory.Received().Create(m_MineField);
        }

        [Test]
        public void CreateMineField_CreatesMineField_ForGivenText()
        {
            // Arrange
            var mineField = Substitute.For <IMineField>();
            mineField.RowsCount.Returns(1);
            mineField.ColumnsCount.Returns(2);
            m_Converter.ToMineField(Arg.Any <string>()).Returns(mineField);
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField("Doesn't matter!");

            // Assert
            Assert.AreEqual(1,
                            mineField.RowsCount,
                            "RowsCount");
            Assert.AreEqual(2,
                            mineField.ColumnsCount,
                            "ColumnsCount");
        }

        [Test]
        public void CreateMineField_CreatesMineField_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_MineFieldFactory.Received().Create(1,
                                                 2);
        }

        [Test]
        public void CreateMineField_CreatesMineLayer_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_MineLayerFactory.Received().Create(m_MineField);
        }

        [Test]
        public void CreateMineField_CreatesPlayingField_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_PlayingFieldFactory.Received().Create(m_MineField);
        }

        [Test]
        public void CreateMineField_CreatesUserOutput_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_UserOutputFactory.Received().Create(m_HintField,
                                                  m_PlayingField);
        }

        [Test]
        public void CreateMineField_PutMinesAtRandomLocation_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();

            // Act
            sut.CreateMineField(1,
                                2,
                                3);

            // Assert
            m_MineLayer.Received().PutMinesAtRandomLocation(3);
        }

        [Test]
        public void DisplayPlayingField_CallsUserOutput_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);

            // Act
            sut.DisplayPlayingField();

            // Assert
            m_UserOutput.Received().DisplayPlayingField();
        }

        [Test]
        public void UserSelectedField_CallsPlayingField_WhenCalled()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);

            // Act
            sut.UserSelectedField(1,
                                  2);

            // Assert
            m_PlayingField.Received().SelectField(1,
                                                  2);
        }

        [Test]
        public void UserSelectedField_UpdatesStatus_WhenPlayerSelectedMine()
        {
            // Arrange
            MineFieldManager sut = CreateSut();
            sut.CreateMineField(1,
                                2,
                                3);
            m_MineField.IsMineAt(1,
                                 2).Returns(true);

            // Act
            sut.UserSelectedField(1,
                                  2);

            // Assert
            Assert.AreEqual(GameStatus.Player.SelectedFieldWithMine,
                            sut.Status);
        }
    }
}