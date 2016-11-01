using System;
using Evaluation.Interfaces.Geometry.Calculators;
using Evaluation.Interfaces.Shapes;
using Selkie.Windsor;

namespace Evaluation.Geometry.Calculators
{
    [ProjectComponent(Lifestyle.Transient)]
    public class DistanceCalculator3D : IDistanceCalculator3D
    {
        public double Calculate(IPoint3D fromPoint,
                                IPoint3D toPoint)
        {
            double deltaX = toPoint.X - fromPoint.X;
            double deltaY = toPoint.Y - fromPoint.Y;
            double deltaZ = toPoint.Z - fromPoint.Z;

            double deltaXSquared = deltaX * deltaX;
            double deltaYSquared = deltaY * deltaY;
            double deltaZSquared = deltaZ * deltaZ;

            double distance = Math.Sqrt(deltaXSquared + deltaYSquared + deltaZSquared);

            return distance;
        }
    }
}