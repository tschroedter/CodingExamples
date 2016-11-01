using System.Diagnostics.CodeAnalysis;
using Evaluation.Geometry.Shapes;
using Evaluation.Importers.CSV;
using Evaluation.Interfaces;
using Evaluation.Interfaces.Importers.CSV;
using NSubstitute;
using NUnit.Framework;

namespace Evaluation.Tests.Importers.CSV
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class CsvIntoRepositoryLoaderTests
    {
        [SetUp]
        public void Setup()
        {
            m_PointOne = new Point3D(1,
                                     2221.367,
                                     4879.073,
                                     1971.682,
                                     "");

            m_PointTwo = new Point3D(2,
                                     2169.996,
                                     5071.648,
                                     2321.178,
                                     "Test");

            m_Points = new[]
                       {
                           m_PointOne,
                           m_PointTwo
                       };

            m_Importer = Substitute.For <IImporter>();
            m_Importer.Points.Returns(m_Points);

            m_Manager = Substitute.For <IPointsManager>();

            m_Sut = new CsvIntoRepositoryLoader(m_Importer,
                                                m_Manager);
        }

        private IImporter m_Importer;
        private IPointsManager m_Manager;
        private Point3D m_PointOne;
        private Point3D m_PointTwo;
        private Point3D[] m_Points;
        private CsvIntoRepositoryLoader m_Sut;

        [Test]
        public void LoadFromCsvFile_CallsAddRange_ForFilename()
        {
            // Arrange
            // Act
            m_Sut.LoadFromCsvFile("filename");

            // Assert
            m_Manager.Received().AddRange(m_Points);
        }

        [Test]
        public void LoadFromCsvFile_CallsClear_ForFilename()
        {
            // Arrange
            // Act
            m_Sut.LoadFromCsvFile("filename");

            // Assert
            m_Manager.Received().Clear();
        }

        [Test]
        public void LoadFromCsvFile_CallsFromFile_ForFilename()
        {
            // Arrange
            // Act
            m_Sut.LoadFromCsvFile("filename");

            // Assert
            m_Importer.Received().FromFile("filename");
        }
    }
}