using System;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MineFieldManager : IMineFieldManager
    {
        private readonly IStringToMineFieldConverter m_Converter;
        private readonly IHintFieldFactory m_HintFieldFactory;
        private readonly IMineFieldFactory m_MineFieldFactory;
        private readonly IMineLayerFactory m_MineLayerFactory;
        private readonly IPlayingFieldFactory m_PlayingFieldFactory;
        private readonly IUserInput m_UserInput;
        private readonly IUserOutputFactory m_UserOutputFactory;

        private IMineField m_MineField;
        private IPlayingField m_PlayingField;
        private IUserOutput m_UserOutput;

        public MineFieldManager([NotNull] IStringToMineFieldConverter converter,
                                [NotNull] IMineFieldFactory mineFieldFactory,
                                [NotNull] IMineLayerFactory mineLayerFactory,
                                [NotNull] IHintFieldFactory hintFieldFactory,
                                [NotNull] IPlayingFieldFactory playingFieldFactory,
                                [NotNull] IUserInput userInput,
                                [NotNull] IUserOutputFactory userOutputFactory)
        {
            m_Converter = converter;
            m_MineFieldFactory = mineFieldFactory;
            m_MineLayerFactory = mineLayerFactory;
            m_HintFieldFactory = hintFieldFactory;
            m_PlayingFieldFactory = playingFieldFactory;
            m_UserInput = userInput;
            m_UserOutputFactory = userOutputFactory;
        }

        public int ColumnsCount
        {
            get
            {
                return m_MineField.ColumnsCount;
            }
        }

        public void CreateMineField(int numberOfRows,
                                    int numberOfColumns,
                                    int numberOfMines)
        {
            m_MineField = m_MineFieldFactory.Create(numberOfRows,
                                                    numberOfColumns);

            IMineLayer mineLayer = m_MineLayerFactory.Create(m_MineField);
            mineLayer.PutMinesAtRandomLocation(numberOfMines);

            CreateCommon();
        }

        public void CreateMineField(string text)
        {
            m_MineField = m_Converter.ToMineField(text);

            CreateCommon();
        }

        public GameStatus.Player Status
        {
            get
            {
                return m_PlayingField.Status;
            }
        }

        public int RowsCount
        {
            get
            {
                return m_MineField.RowsCount;
            }
        }

        public int ColumsCount
        {
            get
            {
                return m_MineField.ColumnsCount;
            }
        }

        public Tuple <int, int> AskUserForRowAndCoumn(int maximumNumberOfRows,
                                                      int maximumNumberOfColumns)
        {
            return m_UserInput.AskUserForRowAndCoumn(maximumNumberOfRows,
                                                     maximumNumberOfColumns);
        }

        public void DisplayPlayingField()
        {
            m_UserOutput.DisplayPlayingField();
        }

        public void UserSelectedField(int row,
                                      int column)
        {
            m_PlayingField.SelectField(row,
                                       column);
        }

        private void CreateCommon()
        {
            IHintField hintField = m_HintFieldFactory.Create(m_MineField);

            m_PlayingField = m_PlayingFieldFactory.Create(m_MineField);

            m_UserOutput = m_UserOutputFactory.Create(hintField,
                                                      m_PlayingField);
        }
    }
}