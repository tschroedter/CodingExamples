using JetBrains.Annotations;
using NUnit.Framework;

namespace WiseTechGlobal.ChequeWriter.Tests
{
    [TestFixture]
    internal sealed class LongToTextConverterTests
    {
        [Test]
        [TestCase(-1, "NEGATIVE one")]
        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        [TestCase(10, "ten")]
        [TestCase(11, "eleven")]
        [TestCase(12, "twelve")]
        [TestCase(13, "thirteen")]
        [TestCase(14, "fourteen")]
        [TestCase(15, "fifteen")]
        [TestCase(16, "sixteen")]
        [TestCase(17, "seventeen")]
        [TestCase(18, "eighteen")]
        [TestCase(19, "nineteen")]
        [TestCase(20, "twenty")]
        [TestCase(30, "thirty")]
        [TestCase(40, "forty")]
        [TestCase(50, "fifty")]
        [TestCase(60, "sixty")]
        [TestCase(70, "seventy")]
        [TestCase(80, "eighty")]
        [TestCase(90, "ninety")]
        [TestCase(91, "ninety one")]
        [TestCase(99, "ninety nine")]
        [TestCase(100, "one hundred")]
        [TestCase(256, "two hundred and fifty six")]
        [TestCase(7256, "seven thousand, two hundred and fifty six")]
        [TestCase(57256, "fifty seven thousand, two hundred and fifty six")]
        [TestCase(357256, "three hundred and fifty seven thousand, two hundred and fifty six")]
        [TestCase(1357256, "one million, three hundred and fifty seven thousand, two hundred and fifty six")]
        public void Convert_ConvertsIntegerToText_ForValidAmount(int amount,
                                                                 [NotNull] string expected)
        {
            // Arrange
            var sut = new LongToTextConverter();

            // Act
            sut.Convert(amount);

            // Assert
            Assert.AreEqual(expected,
                            sut.Text);
        }
    }
}