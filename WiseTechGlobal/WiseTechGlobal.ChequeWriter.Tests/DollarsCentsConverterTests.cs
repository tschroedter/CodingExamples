using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.ChequeWriter.Tests
{
    [TestFixture]
    internal sealed class DollarsCentsConverterTests
    {
        [Test]
        [TestCase("1.0", "one DOLLAR AND zero CENTS")]
        [TestCase("1.1", "one DOLLAR AND one CENT")]
        [TestCase("1.2", "one DOLLAR AND two CENTS")]
        [TestCase("12.34", "twelve DOLLARS AND thirty four CENTS")]
        [TestCase("2.0", "two DOLLARS AND zero CENTS")]
        [TestCase("1357256.32",
            "one million, three hundred and fifty seven thousand, two hundred and fifty six DOLLARS AND thirty two CENTS"
            )]
        public void Convert_ReturnsAmountAsString_ForValidAmount([NotNull] string amount,
                                                                 [NotNull] string expected)
        {
            // Arrange
            var sut = new DollarsCentsConverter();

            // Act
            string actual = sut.Convert(amount);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }

        [Test]
        [TestCase("a.0")]
        [TestCase("0.a")]
        [TestCase("0.")]
        [TestCase("0.123")]
        public void Convert_ThrowsExceptionForInValidAmount([NotNull] string amount)
        {
            // Arrange
            var sut = new DollarsCentsConverter();

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Convert(amount));
        }
    }
}