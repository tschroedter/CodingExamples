using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using IAsset.MicroServices.FlightAssignedToGate.DataAccess;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace IAsset.MicroServices.FlightAssignedToGate.Integration.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    [System.ComponentModel.Category("Integration")]
    internal sealed class FlightAssignedToGateModuleTests
    {
        private const string BasePath = "/flightassignedtogate/";

        private static readonly IFlightAssignedToGateRepository m_Repository = new FlightAssignedToGateRepository();

        private static Browser CreateBrowser()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper,
                                      to => to.Accept("application/json"));
            return browser;
        }

        private void AssertFlightAssignedToGate(IFlightAssignedToGate expected,
                                                IFlightAssignedToGate actual)
        {
            Console.WriteLine("Comparing FlightAssignedToGate with id {0} and {1}...",
                              expected.Id,
                              actual.Id);

            Assert.AreEqual(expected.GateId,
                            actual.GateId,
                            "GateId");

            Assert.AreEqual(expected.FlightId,
                            actual.FlightId,
                            "FlightId");
        }

        private IFlightAssignedToGate CreateItem(Browser browser,
                                                 int id = 1)
        {
            IFlightAssignedToGate model = CreateModelForPutTest(id);

            BrowserResponse result = browser.Post(BasePath,
                                                  with =>
                                                  {
                                                      with.JsonBody(model);
                                                  });

            var response = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate>();

            return response;
        }

        private IFlightAssignedToGate CreateModelForPutTest(int id)
        {
            var model = new DataAccess.FlightAssignedToGate
                        {
                            GateId = 1,
                            FlightId = 11,
                            Id = id
                        };

            return model;
        }

        [Test]
        public void Should_return_JSON_string_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate expected = CreateItem(browser);

            expected.GateId = 2;
            expected.FlightId = 22;

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate>();

            // Then
            AssertFlightAssignedToGate(expected,
                                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Delete(BasePath + expected.Id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            var actual = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate>();

            // Then
            AssertFlightAssignedToGate(expected,
                                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_with_id_exists()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Get(BasePath + expected.Id,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate>();

            // Then
            AssertFlightAssignedToGate(expected,
                                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            IFlightAssignedToGate one = CreateItem(browser,
                                                   1);
            IFlightAssignedToGate two = CreateItem(browser,
                                                   2);

            // When
            BrowserResponse result = browser.Get(BasePath,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate[]>();

            // Then
            Assert.AreEqual(2,
                            actual.Length);
        }

        [Test]
        public void Should_return_status_OK_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate expected = CreateItem(browser);

            expected.GateId = 2;
            expected.FlightId = 22;

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <DataAccess.FlightAssignedToGate>();

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }

        [Test]
        public void Should_return_status_OK_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate item = CreateItem(browser);

            // When
            BrowserResponse result = browser.Delete(BasePath + item.Id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }

        [Test]
        public void Should_return_status_OK_when_item_with_id_exists()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlightAssignedToGate item = CreateItem(browser);

            // When
            BrowserResponse result = browser.Get(BasePath + item.Id,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }

        [Test]
        public void Should_return_status_OK_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            IFlightAssignedToGate one = CreateItem(browser,
                                                   1);
            IFlightAssignedToGate two = CreateItem(browser,
                                                   2);

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