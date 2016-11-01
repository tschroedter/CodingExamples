using System;
using System.Collections.Generic;

namespace KataMinesweeper
{
    public class Field <T>
    {
        private readonly T[,] m_Field;

        public Field(int numberOfRows,
                     int numberOfColumns)
        {
            ValidateNumberOfRowsAndNumberOfColumns(numberOfRows,
                                                   numberOfColumns);

            m_Field = new T[numberOfRows, numberOfColumns];
        }

        public T this[int row,
                      int column]
        {
            get
            {
                CheckIndexes(row,
                             column);

                return m_Field [ row,
                                 column ];
            }

            set
            {
                CheckIndexes(row,
                             column);

                m_Field [ row,
                          column ] = value;
            }
        }

        public int RowsCount
        {
            get
            {
                return m_Field.GetLength(0);
            }
        }

        public int ColumnsCount
        {
            get
            {
                return m_Field.GetLength(1);
            }
        }

        public void CheckIndexes(int row,
                                 int column)
        {
            if ( !IsValidRowIndex(row) )
            {
                throw new ArgumentException("row '" + row + "' is invalid!",
                                            "row");
            }

            if ( !IsValidColumnIndex(column) )
            {
                throw new ArgumentException("column '" + column + "' is invalid!",
                                            "row");
            }
        }

        public bool IsValidRowIndex(int rowIndex)
        {
            if ( rowIndex < 0 ||
                 rowIndex > m_Field.GetLength(0) - 1 )
            {
                return false;
            }

            return true;
        }

        public bool IsValidColumnIndex(int columnIndex)
        {
            if ( columnIndex < 0 ||
                 columnIndex > m_Field.GetLength(1) - 1 )
            {
                return false;
            }

            return true;
        }

        public IEnumerable <T> GetRowAt(int numberOfRow)
        {
            CheckRowIndex(numberOfRow);

            var list = new List <T>();

            for ( var i = 0 ; i < ColumnsCount ; i++ )
            {
                list.Add(m_Field [ numberOfRow,
                                   i ]);
            }

            return list;
        }

        private void CheckRowIndex(int numberOfRow)
        {
            if ( !IsValidRowIndex(numberOfRow) )
            {
                throw new ArgumentException(
                    "numberOfRows '{0}' is invalid! - Rows count is '{1}.".Inject(numberOfRow,
                                                                                  RowsCount));
            }
        }

        public IEnumerable <IEnumerable <T>> Rows()
        {
            var list = new List <IEnumerable <T>>();

            for ( var rowIndex = 0 ; rowIndex < RowsCount ; rowIndex++ )
            {
                IEnumerable <T> row = GetRowAt(rowIndex);

                list.Add(row);
            }

            return list;
        }

        private static void ValidateNumberOfRowsAndNumberOfColumns(int numberOfRows,
                                                                   int numberOfColumns)
        {
            if ( numberOfRows <= 0 ||
                 numberOfColumns <= 0 )
            {
                throw new ArgumentException(
                    "numberOfRows '{0}' or numberOfColumns '{1}' is less or equal 0!".Inject(numberOfRows,
                                                                                             numberOfColumns));
            }
        }
    }
}