using System;
using System.Collections.Generic;
using System.Globalization;
using Importer.Interfaces;
using JetBrains.Annotations;

namespace Importer
{
    public class FfMpeg : IFfMpeg
    {
        private const float SilenceDurationMinimum = 0.2f;
        private const int ColumnType = 3;
        private const int ColumnStartTime = 4;
        private const int ColumnEndTime = 4;
        private const int ColumnDuration = 7;
        private readonly string[] m_Lines;
        private readonly string m_Text;
        private IEnumerable <ISilence> m_Silences = new Silence[0];

        public FfMpeg([NotNull] string text)
        {
            m_Text = text;
            m_Lines = CreateLines(text);
        }

        public IEnumerable <string> Lines
        {
            get
            {
                return m_Lines;
            }
        }

        public string Text
        {
            get
            {
                return m_Text;
            }
        }

        public IEnumerable <ISilence> Silences
        {
            get
            {
                return m_Silences;
            }
        }

        public void Find()
        {
            if ( m_Lines == null )
            {
                // safety, should not happen
                throw new ArgumentException("Text is not set!");
            }

            m_Silences = CreateSilences(m_Lines);
        }

        private string[] CreateLines([NotNull] string text)
        {
            return text.Split(new[]
                              {
                                  "\r\n",
                                  "\n"
                              },
                              StringSplitOptions.None);
        }

        private IEnumerable <ISilence> CreateSilences([NotNull] string[] lines)
        {
            var silences = new List <ISilence>();
            var start = 0.0f;

            foreach ( string line in lines )
            {
                string[] values = line.Split(' ');

                if ( values.Length == 5 ||
                     values.Length == 8 )
                {
                    string type = values [ ColumnType ];

                    if ( type.Contains("silence_start") )
                    {
                        start = float.Parse(values [ ColumnStartTime ],
                                            CultureInfo.InvariantCulture.NumberFormat);

                        continue;
                    }

                    if ( type.Contains("silence_end") )
                    {
                        float duration = float.Parse(values [ ColumnDuration ],
                                                     CultureInfo.InvariantCulture.NumberFormat);

                        if ( ( duration - SilenceDurationMinimum ) < 0.0 )
                        {
                            continue;
                        }

                        float end = float.Parse(values [ ColumnEndTime ],
                                                CultureInfo.InvariantCulture.NumberFormat);

                        var silence = new Silence(start,
                                                  end,
                                                  duration);

                        silences.Add(silence);
                    }
                }
            }

            return silences;
        }
    }
}