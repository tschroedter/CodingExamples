using System;
using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.ChequeWriter.Tests
{
    [TestFixture]
    internal sealed class DollarsCentsToIntegerConverterTests
    {
        [Test]
        [TestCase("0.1", 1)]
        [TestCase("1.10", 10)]
        [TestCase("123.99", 99)]
        [TestCase("1357256.32", 32)]
        public void ToString_SetsCents_ForValidAmount([NotNull] string amount,
                                                      int expected)
        {
            // Arrange
            var sut = new DollarsCentsToLongConverter();

            // Act
            sut.Convert(amount);

            // Assert
            Assert.AreEqual(expected,
                            sut.Cents);
        }

        [Test]
        [TestCase("0.0", 0)]
        [TestCase("1.0", 1)]
        [TestCase("123.0", 123)]
        [TestCase("1357256.32", 1357256)]
        public void ToString_SetsDollars_ForValidAmount([NotNull] string amount,
                                                        int expected)
        {
            // Arrange
            var sut = new DollarsCentsToLongConverter();

            // Act
            sut.Convert(amount);

            // Assert
            Assert.AreEqual(expected,
                            sut.Dollars);
        }

        [Test]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("1.")]
        [TestCase(".1")]
        [TestCase("a.1")]
        [TestCase("1.a")]
        public void ToString_ThrowsException_ForInvalidAmount([NotNull] string amount)
        {
            // Arrange
            var sut = new DollarsCentsToLongConverter();

            // Act
            // Assert
            Assert.Throws <ArgumentException>(() => sut.Convert(amount));
        }
    }
}