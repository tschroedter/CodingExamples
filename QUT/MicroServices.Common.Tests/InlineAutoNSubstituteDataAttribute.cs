using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace MicroServices.Common.Tests
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