using Evaluation.Interfaces;
using Evaluation.Interfaces.Importers;
using Evaluation.Interfaces.Importers.CSV;
using JetBrains.Annotations;
using Selkie.Windsor;

namespace Evaluation.Importers.CSV
{
    [ProjectComponent(Lifestyle.Transient)]
    public sealed class CsvIntoRepositoryLoader : ICsvIntoRepositoryLoader
    {
        private readonly IImporter m_Importer;
        private readonly IPointsManager m_Manager;

        public CsvIntoRepositoryLoader([NotNull] IImporter importer,
                                       [NotNull] IPointsManager manager)
        {
            m_Importer = importer;
            m_Manager = manager;
        }

        public void LoadFromCsvFile(string filename)
        {
            m_Importer.FromFile(filename);

            m_Manager.Clear();

            m_Manager.AddRange(m_Importer.Points);
        }
    }
}