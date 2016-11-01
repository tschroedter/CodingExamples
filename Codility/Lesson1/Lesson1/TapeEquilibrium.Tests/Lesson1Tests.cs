using System;
using System.Linq;
using NUnit.Framework;

namespace TapeEquilibrium.Tests
{
    public class Lesson1Tests
    {
        [Test]
//        [TestCase(new int[0], 0)]
//        [TestCase(new[] { 1 }, 1)]
//        [TestCase(new[] { 1, 1 }, 0)]
//        [TestCase(new[] { 1, 1, 1 }, 1)]
//        [TestCase(new[] { -1 }, 1)]
        [TestCase(new[] { -1, -1 }, 2)]
//        [TestCase(new[] { -1, -1, -1 }, 3)]
//        [TestCase(new[] { 1000 }, 1000)]
//        [TestCase(new[] { 1000, 1000 }, 0)]
//        [TestCase(new[] { 1000, 1000, 1000 }, 1000)]
//        [TestCase(new[] { -1000, 1000 }, 2000)]
//        [TestCase(new[] { -1000 }, 1000)]
//        [TestCase(new[] { -1000, -1000 }, 2000)]
//        [TestCase(new[] { -1000, -1000, -1000 }, 3000)]
//        [TestCase(new[] { 3, 1, 2, 4, 3 }, 1)]
        public void Solution_ReturnsMinimum_WhenCalled(int[] a, int expected)
        {
            Display(a,
                    expected);

            // Arrange
            var sut = CreateSut();

            // Act
            var actual = sut.Solution(a);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        public void Solution_ReturnsZero_ForArrayIsNull()
        {
            // Arrange
            var sut = CreateSut();

            // Act
            var actual = sut.Solution(null);

            // Assert
            Assert.AreEqual(0,
                            actual);
        }

        private void Display(int[] array,
                             int expected)
        {
            var text = string.Join(",",
                                   array);

            Console.WriteLine("Input   : [{0}]", text);
            Console.WriteLine("Expected: {0}", expected);
        }

        [Test]
        [TestCase(100000, 1, 0)]
        [TestCase(100000, 0, 0)]
        [TestCase(100000, -1, 100000)]
        [TestCase(100000, 1000, 0)]
        [TestCase(100000, -1000, 100000000)]
        [TestCase(99999, 1, 1)]
        [TestCase(99999, -1, 99999)]
        [TestCase(99999, -1000, 99999000)]
        [TestCase(99999, 1000, 1000)]
        public void Solution_ReturnsMinimum_ForLargeArray(int size,
                                                          int value,
                                                          int expected)
        {
            // Arrange
            var a = CreateLargeArrayWithSameValue(size,
                                                  value);
            var sut = CreateSut();

            // Act
            var actual = sut.Solution(a);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        private int[] CreateLargeArrayWithSameValue(int size, int value)
        {
            int[] array = Enumerable.Repeat(value,
                                            size).ToArray();

            return array;
        }

        private Lesson1 CreateSut()
        {
            return new Lesson1();
        }
    }
}
