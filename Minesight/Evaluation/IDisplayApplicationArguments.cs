using Evaluation.Interfaces;
using JetBrains.Annotations;

namespace Evaluation
{
    public interface IDisplayApplicationArguments
    {
        void Display([NotNull] IApplicationArguments args);
    }
}