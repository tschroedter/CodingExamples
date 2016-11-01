using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Evaluation.Common.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    internal sealed class StringExtensionsTests
    {
        [Test]
        public void InjectTest()
        {
            const string expected = "Text: Hello World!";
            string actual = "Text: {0} {1}!".Inject("Hello",
                                                    "World");

            Assert.AreEqual(expected,
                            actual);
        }
    }
}