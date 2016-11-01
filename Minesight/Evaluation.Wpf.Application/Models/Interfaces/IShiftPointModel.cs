namespace Evaluation.Wpf.Application.Models.Interfaces
{
    public interface IShiftPointModel
        : IModel
    {
        double X { get; }
        double Y { get; }
        double Z { get; }
    }
}