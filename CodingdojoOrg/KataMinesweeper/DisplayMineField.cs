using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class DisplayMineField : IDisplayMineField
    {
        private readonly IMineField m_MineField;

        public DisplayMineField([NotNull] IMineField mineField)
        {
            m_MineField = mineField;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            IEnumerable <IEnumerable <bool>> rows = m_MineField.Rows();

            foreach ( IEnumerable <bool> row in rows )
            {
                string rowAsString = ConvertRowToString(row);

                builder.AppendLine(rowAsString);
            }

            return builder.ToString();
        }

        private string ConvertRowToString([NotNull] IEnumerable <bool> row)
        {
            var builder = new StringBuilder();

            foreach ( bool column in row )
            {
                string text = column
                                  ? "*"
                                  : ".";

                builder.Append(text);
            }

            return builder.ToString();
        }
    }
}