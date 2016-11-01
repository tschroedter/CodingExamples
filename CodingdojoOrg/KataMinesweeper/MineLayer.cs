using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class MineLayer : IMineLayer
    {
        private readonly IMineField m_MineField;
        private readonly IRandom m_Random;

        public MineLayer([NotNull] IRandom random,
                         [NotNull] IMineField mineField)
        {
            m_Random = random;
            m_MineField = mineField;
        }

        public void PutMinesAtRandomLocation(int numberOfMines)
        {
            for ( var i = 0 ; i < numberOfMines ; i++ )
            {
                int row;
                int column;

                do
                {
                    row = m_Random.Next(0,
                                        m_MineField.RowsCount);
                    column = m_Random.Next(0,
                                           m_MineField.ColumnsCount);
                }
                while ( m_MineField.IsMineAt(row,
                                             column) );

                m_MineField.PutMineAt(row,
                                      column);
            }
        }
    }
}