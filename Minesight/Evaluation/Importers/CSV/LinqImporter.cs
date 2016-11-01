using System;
using System.Collections.Generic;
using System.Linq;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Importers.CSV;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation.Importers.CSV
{
    // todo testing
    [ProjectComponent(Lifestyle.Transient)]
    public class LinqImporter
        : IImporter
    {
        private const int ColumnX = 0;
        private const int ColumnY = 1;
        private const int ColumnZ = 2;
        private const int ColumnId = 3;
        private const int ColumnDescription = 4;
        private readonly IFile m_File;

        public LinqImporter([NotNull] IFile file)
        {
            m_File = file;
            Points = new Point3D[0];
        }

        public IEnumerable <IPoint3D> Points { get; private set; }

        public void FromFile(string filename)
        {
            IEnumerable <Point3D> points = m_File.ReadLines(filename)
                                                 .SelectMany(line => line.Split('\r'))
                                                 .Where(csvLine => !string.IsNullOrWhiteSpace(csvLine))
                                                 .Skip(1) // skip line containing header
                                                 .Select(csvLine => new
                                                                    {
                                                                        data = csvLine.Trim().Split(',')
                                                                    })
                                                 .Select(s => new Point3D(
                                                                  Convert.ToInt32(s.data [ ColumnId ]),
                                                                  Convert.ToDouble(s.data [ ColumnX ]),
                                                                  Convert.ToDouble(s.data [ ColumnY ]),
                                                                  Convert.ToDouble(s.data [ ColumnZ ]),
                                                                  s.data [ ColumnDescription ]));

            Points = points;
        }
    }
}