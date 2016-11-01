namespace Evaluation.Wpf.Application.Models.Interfaces
{
    public interface IQueryPointModel
        : IModel
    {
        double X { get; }
        double Y { get; }
        double Z { get; }
    }
}