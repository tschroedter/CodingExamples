using Evaluation.Geometry.Shapes;
using Evaluation.Wpf.Application.Common.Interfaces;
using Selkie.Windsor;

namespace Evaluation.Wpf.Application.Common
{
    [ProjectComponent(Lifestyle.Singleton)]
    public class SettingsManager
        : ISettingsManager
    {
        private const string DefaultFilename = "Please select a source file...";

        public SettingsManager()
        {
            Filename = DefaultFilename;
            ShiftPoint = new Point3D(-1,
                                     0.0,
                                     0.0,
                                     0.0,
                                     "Shift Point");

            QueryPoint = new Point3D(-1,
                                     0.0,
                                     0.0,
                                     0.0,
                                     "Query Point");

            NumberOfClosestPoints = 3;
        }

        public string Filename { get; set; }
        public Point3D ShiftPoint { get; set; }
        public Point3D QueryPoint { get; set; }
        public int NumberOfClosestPoints { get; set; }
    }
}