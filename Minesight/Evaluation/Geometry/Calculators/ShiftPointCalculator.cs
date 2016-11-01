using Evaluation.Geometry.Shapes;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Shapes;
using Selkie.Windsor;

namespace Evaluation.Geometry.Calculators
{
    [ProjectComponent(Lifestyle.Transient)]
    public class ShiftPointCalculator : IShiftPointCalculator
    {
        public IPoint3D Calculate(IPoint3D sourcePoint3D,
                                  IPoint3D shiftPoint3D)
        {
            double x = sourcePoint3D.X + shiftPoint3D.X;
            double y = sourcePoint3D.Y + shiftPoint3D.Y;
            double z = sourcePoint3D.Z + shiftPoint3D.Z;

            var shiftedPoint3D = new Point3D(sourcePoint3D.Id,
                                             x,
                                             y,
                                             z,
                                             sourcePoint3D.Description);

            return shiftedPoint3D;
        }
    }
}