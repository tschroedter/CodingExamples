using Evaluation.Interfaces.Shapes;
using JetBrains.Annotations;

namespace Evaluation.Geometry.Shapes
{
    [ToString]
    public sealed class Point3D : IPoint3D
    {
        public Point3D(int id,
                       double x,
                       double y,
                       double z,
                       [NotNull] string description)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
            Description = description;
        }

        public int Id { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public string Description { get; private set; }
    }
}