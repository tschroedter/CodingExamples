using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Evaluation.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class InstallerTests
    {
        [SetUp]
        public void Setup()
        {
            m_Sut = new Installer();
        }

        private Installer m_Sut;

        [Test]
        public void GetPrefixOfDllsToInstall_ReturnsString_WhenCalled()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual("Evaluation.",
                            m_Sut.GetPrefixOfDllsToInstall());
        }
    }
}