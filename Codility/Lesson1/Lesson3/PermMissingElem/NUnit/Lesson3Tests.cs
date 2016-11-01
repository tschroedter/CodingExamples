using NUnit.Framework;

namespace PermMissingElem.NUnit
{
    [TestFixture]
    public sealed class Lesson3Tests
    {
        private Lesson3 CreateSut()
        {
            return new Lesson3();
        }

        private int[] CreateLargeArray(int size)
        {
            var array = new int[size];

            for ( var i = 0 ; i < array.Length ; i++ )
            {
                array [ i ] = i;
            }

            return array;
        }

        [Test]
        [TestCase(new int[0], 1)]
        [TestCase(new[]
                  {
                      1
                  }, 1)]
        [TestCase(new[]
                  {
                      1,
                      3
                  }, 2)]
        [TestCase(new[]
                  {
                      1,
                      2
                  }, 3)]
        [TestCase(new[]
                  {
                      3,
                      2
                  }, 1)]
        [TestCase(new[]
                  {
                      2,
                      3,
                      1,
                      5
                  }, 4)]
        public void FunctionUnderTest_ExpectedResult_UnderCondition(int[] a,
                                                                    int expected)
        {
            // Arrange
            Lesson3 sut = CreateSut();

            // Act
            int actual = sut.Solution(a);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void Solution_RetrunsResult_ForLargeArray()
        {
            // Arrange
            int[] a = CreateLargeArray(100000);
            Lesson3 sut = CreateSut();

            // Act
            int actual = sut.Solution(a);

            // Assert
            Assert.AreEqual(100000,
                            actual);
        }
    }
}