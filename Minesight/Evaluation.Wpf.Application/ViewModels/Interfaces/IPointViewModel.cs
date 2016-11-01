namespace Evaluation.Wpf.Application.ViewModels.Interfaces
{
    public interface IPointViewModel
        : IViewModel
    {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}