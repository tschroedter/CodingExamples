using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.RomanNumerals.Tests
{
    [TestFixture]
    internal sealed class RomanNumeralConverterTests
    {
        [Test]
        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(17, "XVII")]
        [TestCase(18, "XVIII")]
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(21, "XXI")]
        [TestCase(40, "XL")]
        [TestCase(50, "L")]
        [TestCase(90, "XC")]
        [TestCase(99, "XCIX")]
        [TestCase(100, "C")]
        [TestCase(400, "CD")]
        [TestCase(500, "D")]
        [TestCase(700, "DCC")]
        [TestCase(899, "DCCCXCIX")]
        [TestCase(900, "CM")]
        [TestCase(999, "CMXCIX")]
        [TestCase(1000, "M")]
        [TestCase(1981, "MCMLXXXI")]
        public void Convert_ReturnsRomanNumerals_ForPositiveIntger(int value,
                                                                   [NotNull] string expected)
        {
            // Arrange
            var sut = new RomanNumeralConverter();

            // Act
            string actual = sut.Convert(value);

            // Assert
            Assert.AreEqual(expected,
                            actual,
                            "Input value: " + value);
        }

        [Test]
        [TestCase("1", "I")]
        [TestCase("2", "II")]
        [TestCase("3", "III")]
        [TestCase("1981", "MCMLXXXI")]
        public void Convert_ReturnsRomanNumerals_ForPositiveIntgerStrings([NotNull] string value,
                                                                          [NotNull] string expected)
        {
            // Arrange
            var sut = new RomanNumeralConverter();

            // Act
            string actual = sut.Convert(value);

            // Assert
            Assert.AreEqual(expected,
                            actual,
                            "Input value: " + value);
        }

        [Test]
        [TestCase("", "I")]
        [TestCase("a", "II")]
        [TestCase("3.123", "III")]
        public void Convert_ThrowsException_ForInvalidStrings([NotNull] string value,
                                                              [NotNull] string expected)
        {
            // Arrange
            var sut = new RomanNumeralConverter();

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Convert(value));
        }
    }
}