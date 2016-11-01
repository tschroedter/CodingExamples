using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using IAsset.MicroServices.Gates.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace IAsset.MicroServices.Gates.Integration.Tests.Nancy
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    [System.ComponentModel.Category("Integration")]
    internal sealed class GatesModuleTests
    {
        private const string BasePath = "/gates/";

        private static readonly IGatesRepository m_Repository = new GatesRepository();

        private static Browser CreateBrowser()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper,
                                      to => to.Accept("application/json"));
            return browser;
        }

        private void AssertGate(IGate expected,
                                IGate actual)
        {
            Console.WriteLine("Comparing Gate with id {0} and {1}...",
                              expected.Id,
                              actual.Id);
        }

        private IGate CreateItem(Browser browser,
                                 int id = 1)
        {
            IGate model = CreateModelForPutTest(id);

            BrowserResponse result = browser.Post(BasePath,
                                                  with =>
                                                  {
                                                      with.JsonBody(model);
                                                  });

            var response = result.Body.DeserializeJson <Gate>();

            return response;
        }

        private IGate CreateModelForPutTest(int id)
        {
            var model = new Gate
                        {
                            Id = id,
                            Description = "Description"
                        };

            return model;
        }

        [Test]
        public void Should_return_JSON_string_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IGate expected = CreateItem(browser);

            expected.Description = "Updated";

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <Gate>();

            // Then
            AssertGate(expected,
                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IGate expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Delete(BasePath + expected.Id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            var actual = result.Body.DeserializeJson <Gate>();

            // Then
            AssertGate(expected,
                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_item_with_id_exists()
        {
            // Given
            Browser browser = CreateBrowser();
            IGate expected = CreateItem(browser);

            // When
            BrowserResponse result = browser.Get(BasePath + expected.Id,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <Gate>();

            // Then
            AssertGate(expected,
                       actual);
        }

        [Test]
        public void Should_return_JSON_string_when_list_requested()
        {
            // Given
            Browser browser = CreateBrowser();

            IGate one = CreateItem(browser,
                                   1);
            IGate two = CreateItem(browser,
                                   2);

            // When
            BrowserResponse result = browser.Get(BasePath,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            var actual = result.Body.DeserializeJson <Gate[]>();

            // Then
            Assert.AreEqual(2,
                            actual.Length);
        }

        [Test]
        public void Should_return_status_OK_when_existing_item_is_updated()
        {
            // Given
            Browser browser = CreateBrowser();
            IGate expected = CreateItem(browser);

            expected.Description = "Updated";

            // When
            BrowserResponse result = browser.Put(BasePath,
                                                 with =>
                                                 {
                                                     with.JsonBody(expected);
                                                 });

            var actual = result.Body.DeserializeJson <Gate>();

            // Then
            Assert.AreEqual(HttpStatusCode.OK,
                            result.StatusCode);
        }

        [Test]
        public void Should_return_status_OK_when_item_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            IGate item = CreateItem(browser);

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
            IGate item = CreateItem(browser);

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

            IGate one = CreateItem(browser,
                                   1);
            IGate two = CreateItem(browser,
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