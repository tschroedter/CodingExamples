using JetBrains.Annotations;
using NUnit.Framework;

namespace LongestSequence.Tests
{
    [TestFixture]
    public sealed class SequenceFinderTests
    {
        private SequenceFinder m_Sut;

        [SetUp]
        public void Setup()
        {
            m_Sut = new SequenceFinder();
        }

        [Test]
        [TestCase(new int[0], -1)]
        [TestCase(new[] {-1}, 0)]
        [TestCase(new[] {0}, 0)]
        [TestCase(new[] {1}, 0)]
        [TestCase(new[] {0, 1, 2}, 0)]
        [TestCase(new[] {4, 0, 1, 2}, 1)]
        [TestCase(new[] {0, 1, 2, 0}, 0)]
        [TestCase(new[] {-2, -1, 0 }, 0)]
        [TestCase(new[] {0, -2, -1, 0 }, 1)]
        [TestCase(new[] {-2, -1, 10, 0, 1, 3, 4 }, 3)]
        [TestCase(new[] {-2, -1, 10, 0, 1, 3, 4 }, 3)]
        [TestCase(new[] {5, 4, 1, 2, 1, 2, 1 }, 2)]
        [TestCase(new[] {5, 4, 1, 2, 1, 2, 1, 2, 3 }, 6)]
        public void FindIndex_ReturnsIndex_WhenCalled([NotNull] int[] numbers,
                                                      int expected)
        {
            // Arrange
            // Act
            var actual = m_Sut.FindIndex(numbers);

            // Assert
            Assert.AreEqual(expected,
                actual);
        }
    }
}
