using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Common.Tests.Extensions;
using IAsset.MicroServices.Gates.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.Nancy;
using IAsset.MicroServices.Gates.Nancy;
using NSubstitute;
using NUnit.Framework;

namespace IAsset.MicroServices.Gates.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    internal sealed class GatesRequestHandlerTests
        : RequestHandlerBaseTests
              <IGate,
              IGatesInformationFinder,
              IGatesRequestHandler>
    {
        private static int NextIdForResponse;

        protected override IGatesInformationFinder CreateFinder()
        {
            return Substitute.For <IGatesInformationFinder>();
        }

        protected override IGatesRequestHandler CreateSut(
            IGatesInformationFinder finder)
        {
            return new GatesRequestHandler(finder);
        }

        protected override IGate CreateResponse()
        {
            return new Gate
                   {
                       Id = NextIdForResponse++
                   };
        }
    }
}