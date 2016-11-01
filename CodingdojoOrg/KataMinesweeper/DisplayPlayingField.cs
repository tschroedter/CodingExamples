using System.Text;
using JetBrains.Annotations;
using KataMinesweeper.Interfaces;
using Selkie.Windsor;

namespace KataMinesweeper
{
    [ProjectComponent(Lifestyle.Transient)]
    public class DisplayPlayingField : IDisplayPlayingField
    {
        private readonly IHintField m_HintField;
        private readonly IPlayingField m_PlayingField;

        public DisplayPlayingField([NotNull] IHintField hintField,
                                   [NotNull] IPlayingField playingField)
        {
            m_HintField = hintField;
            m_PlayingField = playingField;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for ( var row = 0 ; row < m_PlayingField.RowsCount ; row++ )
            {
                for ( var column = 0 ; column < m_PlayingField.ColumnsCount ; column++ )
                {
                    string value = HintOrMine(row,
                                              column);

                    builder.Append(value);
                }

                builder.AppendLine();
            }

            return builder.ToString();
        }

        private string HintOrMine(int row,
                                  int column)
        {
            if ( m_PlayingField.IsSelected(row,
                                           column) )
            {
                string value = ConvertHintToNumberOrMine(row,
                                                         column);

                return value;
            }
            return ".";
        }

        private string ConvertHintToNumberOrMine(int row,
                                                 int column)
        {
            int hintFor = m_HintField.GetHintFor(row,
                                                 column);

            string value = hintFor == -1
                               ? "*"
                               : hintFor.ToString();
            return value;
        }
    }
}