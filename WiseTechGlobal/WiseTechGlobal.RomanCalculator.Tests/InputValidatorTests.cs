using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.RomanCalculator.Tests
{
    [TestFixture]
    internal sealed class InputValidatorTests
    {
        [Test]
        [TestCase("", false)]
        [TestCase("I", true)]
        [TestCase("V", true)]
        [TestCase("X", true)]
        [TestCase("L", true)]
        [TestCase("C", true)]
        [TestCase("D", true)]
        [TestCase("M", true)]
        [TestCase("II", true)]
        [TestCase("VV", true)]
        [TestCase("XX", true)]
        [TestCase("LL", true)]
        [TestCase("CC", true)]
        [TestCase("DD", true)]
        [TestCase("MM", true)]
        [TestCase("IVXLCDM", true)]
        [TestCase("a", false)]
        [TestCase("aa", false)]
        public void Convert_ReturnsAmountAsString_ForValidAmount([NotNull] string amount,
                                                                 bool expected)
        {
            // Arrange
            var sut = new InputValidator();

            // Act
            // Assert
            Assert.AreEqual(expected,
                            sut.IsValid(amount),
                            "Amount: " + amount);
        }
    }
}