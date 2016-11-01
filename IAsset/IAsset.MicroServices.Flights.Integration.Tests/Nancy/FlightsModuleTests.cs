using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using IAsset.MicroServices.Flights.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace IAsset.MicroServices.Flights.Integration.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    [System.ComponentModel.Category("Integration")]
    internal sealed class FlightsModuleTests
    {
        private const string BasePath = "/flights/";

        private static readonly IFlightsRepository m_Repository = new FlightsRepository();

        private static Browser CreateBrowser()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper,
                                      to => to.Accept("application/json"));
            return browser;
        }

        private void AssertFlight(IFlight expected,
                                  IFlight actual)
        {
            Console.WriteLine("Comparing Flight with id {0} and {1}...",
                              expected.Id,
                              actual.Id);

            Assert.AreEqual(expected.Arrival,
                            actual.Arrival,
                            "Arrival");

            Assert.AreEqual(expected.Departure,
                            actual.Departure,
                            "Departure");
        }

        private IFlight CreateItem(Browser browser,
                                   int id = 1)
        {
            IFlight model = CreateModelForPutTest(id);

            BrowserResponse result = browser.Post(BasePath,
                                                  with =>
                                                  {
                                                      with.JsonBody(model);
                                                  });

            var response = result.Body.DeserializeJson <Flight>();

            return response;
        }

        private IFlight CreateModelForPutTest(int id)
        {
            var model = new Flight
                        {
                            Arrival = DateTime.Parse("01/01/2016 8:00"),
                            Departure = DateTime.Parse("01/01/2016 8:30"),
                            Id = id
                        };

            return model;
        }

        [Test]
        public void Should_return_JSON_string_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlight expected = CreateItem(browser);

            expected.Arrival = DateTime.Parse("01/01/2016 18:00");
            expected.Departure = DateTime.Parse("01/01/2016 18:30");

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <Flight>();

            // Then
            AssertFlight(expected,
                         actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlight expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Delete(BasePath + expected.Id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            var actual = result.Body.DeserializeJson <Flight>();

            // Then
            AssertFlight(expected,
                         actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_with_id_exists()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlight expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Get(BasePath + expected.Id,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <Flight>();

            // Then
            AssertFlight(expected,
                         actual);
        }

        [Test]
        public void Should_return_JSON_string_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            IFlight one = CreateItem(browser,
                                     1);
            IFlight two = CreateItem(browser,
                                     2);

            // When
            BrowserResponse result = browser.Get(BasePath,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <Flight[]>();

            // Then
            Assert.AreEqual(2,
                            actual.Length);
        }

        [Test]
        public void Should_return_status_OK_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlight expected = CreateItem(browser);

            expected.Arrival = DateTime.Parse("01/01/2016 20:00");
            expected.Departure = DateTime.Parse("01/01/2016 20:30");

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <Flight>();

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }

        [Test]
        public void Should_return_status_OK_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IFlight item = CreateItem(browser);

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
            IFlight item = CreateItem(browser);

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

            IFlight one = CreateItem(browser,
                                     1);
            IFlight two = CreateItem(browser,
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