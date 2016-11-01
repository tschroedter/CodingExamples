using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.Gates.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.Nancy;
using IAsset.MicroServices.Gates.Nancy;
using JetBrains.Annotations;
using NSubstitute;

namespace IAsset.MicroServices.Flights.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    internal sealed class GatesInformationFinderTests
        : InformationFinderBaseTests
              <IGate,
              IGate,
              IGatesRepository,
              IGatesInformationFinder>
    {
        private static int NextIdForResponse;
        private static int NextIdForEntity;

        protected override IGate CreateEntity()
        {
            return new Gate
                   {
                       Id = NextIdForEntity++
                   };
        }

        protected override IGatesRepository CreateRepository()
        {
            return Substitute.For <IGatesRepository>();
        }

        protected override IGate CreateResponse()
        {
            return new Gate
                   {
                       Id = NextIdForResponse++
                   };
        }

        protected override IGatesInformationFinder CreateSut(
            [NotNull] IGatesRepository repository)
        {
            return new GatesInformationFinder(repository);
        }
    }
}