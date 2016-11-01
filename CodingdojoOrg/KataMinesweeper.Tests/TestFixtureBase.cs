using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;

namespace KataMinesweeper.Tests
{
    internal abstract class TestFixtureBase <T>
    {
        protected IFixture Fixture { get; private set; }

        protected T Sut { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            Fixture = new Fixture()
                .Customize(new AutoNSubstituteCustomization());

            Sut = CreateSut();
        }

        protected virtual T CreateSut()
        {
            FreezeDependency();

            var sut = Fixture.Create <T>();

            return sut;
        }

        protected abstract void FreezeDependency();
    }
}