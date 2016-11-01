using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using IAsset.MicroServices.FlightAssignedToGate.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace IAsset.MicroServices.FlightsAssignedToGates.Integration.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    [System.ComponentModel.Category("Integration")]
    internal sealed class FlightsAssignedToGatesModuleTests
    {
        private const string BasePath = "/flightsassignedtogates/";

        private static readonly IFlightAssignedToGateRepository m_Repository = new FlightAssignedToGateRepository();

        private static Browser CreateBrowser()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper,
                                      to => to.Accept("application/json"));
            return browser;
        }

        private void AssertFlightsAssignedToGates(IFlightsAssignedToGates expected,
                                                  IFlightsAssignedToGates actual)
        {
            Console.WriteLine("Comparing IFlightsAssignedToGates with GateId {0} and {1}...",
                              expected.GateId,
                              actual.GateId);

            Assert.True(expected.FlightIds.SequenceEqual(actual.FlightIds),
                        "FlightIds");
        }

        [Test]
        public void Should_return_JSON_string_when_item_with_id_exists()
        {
            // Given
            Browser browser = CreateBrowser();

            var gateId = 1;
            var flightIds = new[]
                            {
                                11,
                                12
                            };
            var expected = new FlightsAssignedToGates.Nancy.FlightsAssignedToGates
                           {
                               GateId = gateId,
                               FlightIds = flightIds
                           };

            // When
            BrowserResponse result = browser.Get(BasePath + gateId,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <FlightsAssignedToGates.Nancy.FlightsAssignedToGates>();

            // Then
            AssertFlightsAssignedToGates(expected,
                                         actual);
        }

        [Test]
        public void Should_return_JSON_string_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get(BasePath,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual =
                result.Body
                      .DeserializeJson
                    <FlightsAssignedToGates.Nancy.FlightsAssignedToGates[]>();

            // Then
            Assert.AreEqual(2,
                            actual.Length);
        }

        [Test]
        public void Should_return_status_OK_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get(BasePath,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }
    }
}