namespace Evaluation.Wpf.Application.View.Interfaces
{
    public interface IView
    {
        object GetContent();
        void Show();
        bool? ShowDialog();
    }
}