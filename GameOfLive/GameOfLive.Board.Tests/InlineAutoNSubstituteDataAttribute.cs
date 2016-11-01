using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace GameOfLive.Board.Tests
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class InlineAutoNSubstituteDataAttribute : CompositeDataAttribute
    {
        public InlineAutoNSubstituteDataAttribute([NotNull] params object[] values)
            : base(new InlineDataAttribute(values),
                   new AutoNSubstituteDataAttribute())
        {
        }
    }
}