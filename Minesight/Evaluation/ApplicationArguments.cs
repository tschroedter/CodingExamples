using System;
using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation
{
    public class ApplicationArguments : IApplicationArguments
    {
        public string Source { get; set; }
        public int NumberOfClosestPoints { get; set; }
        public string QueryPointCoordinates { get; set; }
        public string ShiftPointCoordinates { get; set; }
        public bool Verbose { get; set; }

        public IPoint3D GetQueryPoint3D()
        {
            return ConvertStringToPoint3D(QueryPointCoordinates,
                                          "Query Point");
        }

        public IPoint3D GetShiftVector3D()
        {
            return ConvertStringToPoint3D(ShiftPointCoordinates,
                                          "Shift Vector");
        }

        private IPoint3D ConvertStringToPoint3D([NotNull] string text,
                                                [NotNull] string description)
        {
            try
            {
                string[] array = text.Split(' ');

                double x = Convert.ToDouble(array [ 0 ]);
                double y = Convert.ToDouble(array [ 1 ]);
                double z = Convert.ToDouble(array [ 2 ]);

                return new Point3D(-1,
                                   x,
                                   y,
                                   z,
                                   description);
            }
            catch ( FormatException exception )
            {
                throw new FormatException("Can't convert '{0}' to X,Y,Z coordinates!",
                                          exception);
            }
        }
    }
}