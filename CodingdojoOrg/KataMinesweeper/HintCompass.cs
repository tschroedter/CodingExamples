using System;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class HintCompass : IHintCompass
    {
        internal const int Mine = -1;
        private readonly Func <IMineField, int, int, int>[] m_Functions;
        private readonly IMineField m_MineField;

        public HintCompass([NotNull] IMineField mineField)
        {
            m_MineField = mineField;

            m_Functions = new Func <IMineField, int, int, int>[]
                          {
                              AddOneIfDirectionIsNorth,
                              AddOneIfDirectionIsNorthEast,
                              AddOneIfDirectionIsEast,
                              AddOneIfDirectionIsSouthEast,
                              AddOneIfDirectionIsSouth,
                              AddOneIfDirectionIsSouthWest,
                              AddOneIfDirectionIsWest,
                              AddOneIfDirectionIsNorthWest
                          };
        }

        public int GetMineCountFor(int rowIndex,
                                   int columnIndex)
        {
            if ( m_MineField.IsMineAt(rowIndex,
                                      columnIndex) )
            {
                return Mine;
            }

            return CalculateHint(rowIndex,
                                 columnIndex);
        }

        private int CalculateHint(int rowIndex,
                                  int columnIndex)
        {
            var surroundingMineCount = 0;

            foreach ( Func <IMineField, int, int, int> function in m_Functions )
            {
                int mineCount = function.Invoke(m_MineField,
                                                rowIndex,
                                                columnIndex);

                surroundingMineCount += mineCount;
            }

            return surroundingMineCount;
        }

        private int AddOneIfDirectionIsNorth([NotNull] IMineField mineField,
                                             int rowIndex,
                                             int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineNorth,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsNorthEast([NotNull] IMineField mineField,
                                                 int rowIndex,
                                                 int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineNorthEast,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsEast([NotNull] IMineField mineField,
                                            int rowIndex,
                                            int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineEast,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsSouthEast([NotNull] IMineField mineField,
                                                 int rowIndex,
                                                 int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineSouthEast,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsSouth([NotNull] IMineField mineField,
                                             int rowIndex,
                                             int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineSouth,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsSouthWest([NotNull] IMineField mineField,
                                                 int rowIndex,
                                                 int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineSouthWest,
                                  rowIndex,
                                  columnIndex);
        }


        private int AddOneIfDirectionIsWest([NotNull] IMineField mineField,
                                            int rowIndex,
                                            int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineWest,
                                  rowIndex,
                                  columnIndex);
        }

        private int AddOneIfDirectionIsNorthWest([NotNull] IMineField mineField,
                                                 int rowIndex,
                                                 int columnIndex)
        {
            return AddOneIfMineIs(mineField,
                                  IsMineNorthWest,
                                  rowIndex,
                                  columnIndex);
        }

        private static int AddOneIfMineIs([NotNull] IMineField mineField,
                                          Func <IMineField, int, int, bool> isMineInDirection,
                                          int rowIndex,
                                          int columnIndex)
        {
            bool isThereMine = isMineInDirection(mineField,
                                                 rowIndex,
                                                 columnIndex);
            return isThereMine
                       ? 1
                       : 0;
        }

        private bool IsValidRowIndex(int rowIndex)
        {
            if ( rowIndex < 0 ||
                 rowIndex > m_MineField.RowsCount - 1 )
            {
                return false;
            }

            return true;
        }

        private bool IsValidColumnIndex(int columnIndex)
        {
            if ( columnIndex < 0 ||
                 columnIndex > m_MineField.ColumnsCount - 1 )
            {
                return false;
            }

            return true;
        }

        private bool IsMineNorth(IMineField mineField,
                                 int rowIndex,
                                 int columnIndex)
        {
            int currentRow = rowIndex - 1;
            int currentColumn = columnIndex;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineNorthEast(IMineField mineField,
                                     int rowIndex,
                                     int columnIndex)
        {
            int currentRow = rowIndex - 1;
            int currentColumn = columnIndex + 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineEast(IMineField mineField,
                                int rowIndex,
                                int columnIndex)
        {
            int currentRow = rowIndex;
            int currentColumn = columnIndex + 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineSouthEast(IMineField mineField,
                                     int rowIndex,
                                     int columnIndex)
        {
            int currentRow = rowIndex + 1;
            int currentColumn = columnIndex + 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }


        private bool IsMineSouth(IMineField mineField,
                                 int rowIndex,
                                 int columnIndex)
        {
            int currentRow = rowIndex + 1;
            int currentColumn = columnIndex;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineSouthWest(IMineField mineField,
                                     int rowIndex,
                                     int columnIndex)
        {
            int currentRow = rowIndex + 1;
            int currentColumn = columnIndex - 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }

            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineWest(IMineField mineField,
                                int rowIndex,
                                int columnIndex)
        {
            int currentRow = rowIndex;
            int currentColumn = columnIndex - 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }
            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }

        private bool IsMineNorthWest(IMineField mineField,
                                     int rowIndex,
                                     int columnIndex)
        {
            int currentRow = rowIndex - 1;
            int currentColumn = columnIndex - 1;

            if ( !IsValidRowIndex(currentRow) )
            {
                return false;
            }

            if ( !IsValidColumnIndex(currentColumn) )
            {
                return false;
            }
            bool isMineAt = mineField.IsMineAt(currentRow,
                                               currentColumn);

            return isMineAt;
        }
    }
}