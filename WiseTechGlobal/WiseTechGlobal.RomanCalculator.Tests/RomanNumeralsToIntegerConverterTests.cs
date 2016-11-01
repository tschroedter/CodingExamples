using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.RomanCalculator.Tests
{
    [TestFixture]
    internal sealed class RomanNumeralsToIntegerConverterTests
    {
        [Test]
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("IX", 9)]
        [TestCase("X", 10)]
        [TestCase("XI", 11)]
        [TestCase("XII", 12)]
        [TestCase("XIII", 13)]
        [TestCase("XIV, 14")]
        [TestCase("XV", 15)]
        [TestCase("XVI", 16)]
        [TestCase("XVII", 17)]
        [TestCase("XVIII", 18)]
        [TestCase("XIX", 19)]
        [TestCase("XX", 20)]
        [TestCase("XLIX", 49)]
        [TestCase("L", 50)]
        [TestCase("LI", 51)]
        [TestCase("XCIX", 99)]
        [TestCase("C", 100)]
        [TestCase("CI", 101)]
        [TestCase("CC", 200)]
        [TestCase("CDXCIX", 499)]
        [TestCase("D", 500)]
        [TestCase("DI", 501)]
        [TestCase("CMXCIX", 999)]
        [TestCase("M", 1000)]
        [TestCase("MI", 1001)]
        [TestCase("MCMLXXIII", 1973)]
        [TestCase("MM", 2000)]
        public void Convert_ReturnsAmountAsString_ForValidAmount([NotNull] string numerals,
                                                                 int expected)
        {
            // Arrange
            var sut = new RomanNumeralsToIntegerConverter();

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.Convert(numerals),
                            "Numerals: " + numerals);
        }
    }
}