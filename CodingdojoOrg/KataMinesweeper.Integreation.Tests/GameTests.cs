using System;
using System.Diagnostics.CodeAnalysis;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using KataMinesweeper.Interfaces;
using NUnit.Framework;

namespace KataMinesweeper.Integreation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class GameTests
    {
        [SetUp]
        public void Setup()
        {
            try
            {
                m_Container = new WindsorContainer();

                m_Container.Register(Component.For <IConsole>()
                                              .ImplementedBy <ConsoleForTesting>()
                                              .LifestyleSingleton());

                var installers = new IWindsorInstaller[]
                                 {
                                     new Selkie.Windsor.Installer(),
                                     new Interfaces.Installer(),
                                     new Installer()
                                 };

                m_Container.Install(installers);

                m_Console = ( ConsoleForTesting ) m_Container.Resolve <IConsole>();

                Sut = m_Container.Resolve <IGame>();
            }
            catch ( Exception ex )
            {
                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        private readonly string m_MineFieldWithTwoMines =
            "*.\r\n" +
            ".*";

        private WindsorContainer m_Container;
        private ConsoleForTesting m_Console;

        public IGame Sut { get; set; }

        private readonly string[] m_ExpectedLinesPlayerWins =
        {
            "Minefield:",
            "..\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n2.\r\n",
            "You won!"
        };

        private readonly string[] m_ExpectedLinesPlayerWonWithInvalidRow =
        {
            "Minefield:",
            "..\r\n..\r\n",
            "Input Row, Column: " +
            "Error: Input string was not in a correct format.",
            "Error: Row must be between 0 and 1!",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n2.\r\n",
            "You won!"
        };

        private readonly string[] m_ExpectedLinesPlayerWonWithInvalidColumn =
        {
            "Minefield:",
            "..\r\n..\r\n",
            "Input Row, Column: " +
            "Error: Input string was not in a correct format.",
            "Error: Column must be between 0 and 1!",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n2.\r\n",
            "You won!"
        };

        private readonly string[] m_ExpectedLinesPlayerLosses =
        {
            "Minefield:",
            "..\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n..\r\n",
            "Input Row, Column: ",
            "Minefield:",
            ".2\r\n.*\r\n",
            "You hit a mine!"
        };

        private void AssertStringArray(string[] expectedLines,
                                       string[] actualLines)
        {
            Assert.AreEqual(expectedLines.Length,
                            actualLines.Length,
                            "Length");

            for ( var i = 0 ; i < expectedLines.Length ; i++ )
            {
                string expected = expectedLines [ i ];
                string actual = actualLines [ i ];

                Assert.AreEqual(expected,
                                actual,
                                "[{0}]".Inject(i));
            }
        }

        [Test]
        public void Game_Finishes_WhenPlayerLosses()
        {
            // Arrange
            m_Console.ReadLines = new[]
                                  {
                                      "0,1",
                                      "1,1"
                                  };

            Sut.Initialize(m_MineFieldWithTwoMines);

            // Act
            Sut.Start();

            // Assert
            AssertStringArray(m_ExpectedLinesPlayerLosses,
                              m_Console.WrittenLines());
        }

        [Test]
        public void Game_Finishes_WhenPlayerWins()
        {
            // Arrange
            m_Console.ReadLines = new[]
                                  {
                                      "0,1",
                                      "1,0"
                                  };

            Sut.Initialize(m_MineFieldWithTwoMines);

            // Act
            Sut.Start();

            // Assert
            AssertStringArray(m_ExpectedLinesPlayerWins,
                              m_Console.WrittenLines());
        }

        [Test]
        public void Game_FinishesAndHandlesInvalidColumn_WhenPlayerWins()
        {
            // Arrange
            m_Console.ReadLines = new[]
                                  {
                                      "0,a",
                                      "0,1",
                                      "1,0"
                                  };

            Sut.Initialize(m_MineFieldWithTwoMines);

            // Act
            Sut.Start();

            // Assert
            AssertStringArray(m_ExpectedLinesPlayerWonWithInvalidColumn,
                              m_Console.WrittenLines());
        }

        [Test]
        public void Game_FinishesAndHandlesInvalidRow_WhenPlayerWins()
        {
            // Arrange
            m_Console.ReadLines = new[]
                                  {
                                      "a,0",
                                      "0,1",
                                      "1,0"
                                  };

            Sut.Initialize(m_MineFieldWithTwoMines);

            // Act
            Sut.Start();

            // Assert
            AssertStringArray(m_ExpectedLinesPlayerWonWithInvalidRow,
                              m_Console.WrittenLines());
        }
    }
}