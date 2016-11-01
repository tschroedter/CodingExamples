using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Interfaces
{
    public interface IApplicationArguments
    {
        string Source { get; set; }
        int NumberOfClosestPoints { get; set; }
        string QueryPointCoordinates { get; set; }
        string ShiftPointCoordinates { get; set; }
        bool Verbose { get; set; }

        [NotNull]
        IPoint3D GetQueryPoint3D();

        [NotNull]
        IPoint3D GetShiftVector3D();
    }
}