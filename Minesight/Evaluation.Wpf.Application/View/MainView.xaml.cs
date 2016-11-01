using Evaluation.Wpf.Application.View.Interfaces;
using Evaluation.Wpf.Application.ViewModels.Interfaces;
using JetBrains.Annotations;

namespace Evaluation.Wpf.Application.View
{
    public partial class MainView
        : IMainView
    {
        public MainView(
            [NotNull, UsedImplicitly] IMainViewModel viewModel)
        {
            InitializeComponent();
        }

        public object GetContent()
        {
            return Content;
        }
    }
}