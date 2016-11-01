using Selkie.Windsor;

namespace Evaluation.Wpf.Application.View.Interfaces
{
    public interface IViewFactory : ITypedFactory
    {
        T CreateView <T>() where T : IView;
        T CreateView <T>(object argumentsAsAnonymousType) where T : IView;
    }
}