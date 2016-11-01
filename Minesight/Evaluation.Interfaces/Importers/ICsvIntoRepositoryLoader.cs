using JetBrains.Annotations;

namespace Evaluation.Interfaces.Importers
{
    public interface ICsvIntoRepositoryLoader
    {
        void LoadFromCsvFile([NotNull] string filename);
    }
}