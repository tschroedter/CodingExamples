namespace Evaluation.Interfaces.Shapes
{
    public interface IPoint3D
    {
        int Id { get; }
        double X { get; }
        double Y { get; }
        double Z { get; }
        string Description { get; }
    }
}