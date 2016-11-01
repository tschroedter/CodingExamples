using Evaluation.Geometry.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.Common.Interfaces
{
    public interface ISettingsManager
    {
        [NotNull]
        string Filename { get; set; }

        Point3D ShiftPoint { get; set; }
        int NumberOfClosestPoints { get; set; }
        Point3D QueryPoint { get; set; }
    }
}