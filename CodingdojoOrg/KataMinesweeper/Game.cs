using System;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class Game : IGame
    {
        private readonly IConsole m_Console;
        private readonly IMineFieldManager m_Manager;

        public Game([NotNull] IConsole console,
                    [NotNull] IMineFieldManager manager)
        {
            m_Console = console;
            m_Manager = manager;
        }

        public void Initialize(string text)
        {
            m_Manager.CreateMineField(text);
            m_Manager.DisplayPlayingField();
        }

        public void Initialize(int numberOfRows,
                               int numberOfColumns,
                               int numberOfMines)
        {
            m_Manager.CreateMineField(numberOfRows,
                                      numberOfColumns,
                                      numberOfMines);

            m_Manager.DisplayPlayingField();
        }

        public void Start()
        {
            bool isFinished;

            do
            {
                isFinished = PlayOneRound();
            }
            while ( !isFinished );
        }

        internal bool PlayOneRound()
        {
            Tuple <int, int> rowAndColumn = m_Manager.AskUserForRowAndCoumn(m_Manager.RowsCount - 1,
                                                                            m_Manager.ColumsCount - 1);

            int row = rowAndColumn.Item1;
            int column = rowAndColumn.Item2;

            m_Manager.UserSelectedField(row,
                                        column);

            m_Manager.DisplayPlayingField();

            bool isFinished = IsGameFinished(m_Manager.Status);

            return isFinished;
        }

        internal bool IsGameFinished(GameStatus.Player status)
        {
            switch ( status )
            {
                case GameStatus.Player.SelectedFieldWithMine:
                    m_Console.WriteLine("You hit a mine!");
                    return true;

                case GameStatus.Player.SelectedFieldWithoutMine:
                    return false;

                case GameStatus.Player.HasWon:
                    m_Console.WriteLine("You won!");
                    return true;

                default:
                    throw new Exception("Unknown Status: " + m_Manager.Status);
            }
        }
    }
}