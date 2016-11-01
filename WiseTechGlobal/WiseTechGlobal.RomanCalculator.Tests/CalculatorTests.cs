using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.RomanCalculator.Tests
{
    [TestFixture]
    internal sealed class CalculatorTests
    {
        [Test]
        [TestCase("XX", "II", "XXII")]
        [TestCase("I", "V", "VI")]
        [TestCase("II", "II", "IV")]
        [TestCase("CCC", "CCC", "DC")]
        [TestCase("D", "D", "M")]
        [TestCase("I", "I", "II")]
        [TestCase("V", "V", "X")]
        [TestCase("L", "L", "C")]
        [TestCase("C", "C", "CC")]
        [TestCase("IV", "IV", "VIII")]
        [TestCase("IX", "X", "XIX")]
        [TestCase("MCML", "XXIII", "MCMLXXIII")]
        [TestCase("XV", "VIII", "XXIII")]
        public void Add_ReturnsSumAsString_ForValidInput([NotNull] string valueOne,
                                                         [NotNull] string valueTwo,
                                                         [NotNull] string expected)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            string actual = sut.Add(valueOne,
                                    valueTwo);

            // Assert
            Assert.AreEqual(expected,
                            actual,
                            valueOne + " + " + valueTwo);
        }

        [Test]
        [TestCase("", "I")]
        [TestCase("I", "")]
        [TestCase("", "")]
        public void Add_ThrowsException_ForInvalidValues([NotNull] string valueOne,
                                                         [NotNull] string valueTwo)
        {
            // Arrange
            var sut = new Calculator();

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Add(valueOne,
                                                            valueTwo));
        }
    }
}