﻿using System.Diagnostics.CodeAnalysis;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit;

namespace MicroServices.Common.Tests
{
    [ExcludeFromCodeCoverage]
    //ncrunch: no coverage start
    public class AutoNSubstituteDataAttribute : AutoDataAttribute
    {
        public AutoNSubstituteDataAttribute()
            : base(new Fixture().Customize(new AutoConfiguredNSubstituteCustomization()))
        {
        }
    }
}