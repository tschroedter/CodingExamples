using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using MicroServices.Nancy.Persons.Interfaces;
using Nancy;
using Nancy.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Extensions;

namespace MicroServices.Nancy.Persons.Tests.Integration.Nancy
{
    public sealed class PersonsModuleTests
    {
        [Fact]
        public void Should_return_JSON_string_when_person_is_created_for_put()
        {
            dynamic actual = null;

            try
            {
                // Given
                IPersonForResponse model = CreateModelForPutTest();
                dynamic expected = CreateExpectedResponseForPutTest();
                Browser browser = CreateBrowser();

                // When
                BrowserResponse result = browser.Put("/person/",
                                                     with =>
                                                     {
                                                         with.JsonBody(model);
                                                     });

                actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

                // Then
                XUnitPersonsHelper.AssertPersonIgnoreId(expected,
                                                        actual);
            }
            finally
            {
                if ( actual != null )
                {
                    int id = Convert.ToInt32(actual [ "Id" ].Value);

                    DeleteDoctorById(id);
                }
            }
        }

        [Fact]
        public void Should_return_JSON_string_when_person_is_created()
        {
            dynamic actual = null;

            try
            {
                // Given
                dynamic expected = CreateExpectedResponseForCreate();
                Browser browser = CreateBrowser();

                // When
                BrowserResponse result = browser.Post("/person/",
                                                      with =>
                                                      {
                                                          with.HttpRequest();
                                                      });

                actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

                // Then
                XUnitPersonsHelper.AssertPersonIgnoreId(expected,
                                                        actual);
            }
            finally
            {
                if ( actual != null )
                {
                    var id = ( long ) actual [ "Id" ].Value;

                    DeleteDoctorById(id);
                }
            }
        }

        [Fact]
        public void Should_return_status_OK_when_person_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            dynamic person = CreateDoctorToBeDeleted(browser);
            int id = Convert.ToInt32(person [ "Id" ].Value);

            // When
            BrowserResponse result = browser.Delete("/person/" + id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            // Then
            Assert.Equal(HttpStatusCode.OK,
                         result.StatusCode);
        }

        [Fact]
        public void Should_return_JSON_string_when_person_is_deleted()
        {
            // Given
            Browser browser = CreateBrowser();
            dynamic person = CreateDoctorToBeDeleted(browser);
            int personId = Convert.ToInt32(person [ "Id" ].Value);
            dynamic expected = CreatedExpectedDoctorFor(personId);

            // When
            BrowserResponse result = browser.Delete("/person/" + personId,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

            // Then
            XUnitPersonsHelper.AssertPerson(expected,
                                            actual);
        }

        [Fact]
        public void Should_return_JSON_string_when_person_is_updated()
        {
            IPersonForResponse model = null;

            try
            {
                // Given
                Browser browser = CreateBrowser();
                dynamic person = CreateDoctorToBeDeleted(browser);
                model = CreateModelForUpdate(person);

                dynamic expected = CreatedExpectedDoctorForUpdate(model.Id);

                // When
                BrowserResponse result = browser.Put("/person/",
                                                     with =>
                                                     {
                                                         with.JsonBody(model);
                                                     });

                dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

                // Then
                XUnitPersonsHelper.AssertPerson(expected,
                                                actual);
            }
            finally
            {
                if ( model != null )
                {
                    DeleteDoctorById(model.Id);
                }
            }
        }

        [Fact]
        public void Should_update_database_when_person_is_updated()
        {
            IPersonForResponse model = null;

            try
            {
                // Given
                Browser browser = CreateBrowser();
                dynamic person = CreateDoctorToBeDeleted(browser);
                model = CreateModelForUpdate(person);

                // When
                BrowserResponse result = browser.Put("/person/",
                                                     with =>
                                                     {
                                                         with.JsonBody(model);
                                                     });

                // Then
                Assert.Equal(HttpStatusCode.OK,
                             result.StatusCode);

                // *** Post-conditions ***
                // Given
                dynamic expected = CreatedExpectedDoctorForUpdate(model.Id);

                // When
                result = browser.Get("/person/" + model.Id,
                                     with =>
                                     {
                                         with.HttpRequest();
                                     });

                dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

                // Then
                XUnitPersonsHelper.AssertPerson(expected,
                                                actual);
            }
            finally
            {
                if ( model != null )
                {
                    DeleteDoctorById(model.Id);
                }
            }
        }

        [Fact]
        public void Should_return_JSON_string_when_person_with_id_exists()
        {
            // Given
            dynamic expected = CreateExpectedResponseForMiller();
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get("/person/1",
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

            // Then
            XUnitPersonsHelper.AssertPerson(expected,
                                            actual);
        }

        [Fact]
        public void Should_return_JSON_string_when_list_requested()
        {
            // Given
            dynamic expected = CreateExpectedJsonStringForList();
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get("/person/",
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

            // Then
            XUnitPersonsHelper.AssertDoctors(expected,
                                             actual);
        }

        [Theory]
        [InlineData("/person/")]
        [InlineData("/person/1")]
        public void Should_return_JSON_when_requested([NotNull] string url)
        {
            // Given
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get(url,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            // Then
            Assert.Equal("application/json",
                         result.ContentType);
        }

        [Theory]
        [InlineData("/person/", HttpStatusCode.OK)]
        [InlineData("/person/1", HttpStatusCode.OK)]
        [InlineData("/person/-1", HttpStatusCode.NotFound)]
        public void Should_return_status_OK_when_requested([NotNull] string url,
                                                           HttpStatusCode status)
        {
            // Given
            Browser browser = CreateBrowser();

            // When
            BrowserResponse result = browser.Get(url,
                                                 with =>
                                                 {
                                                     with.HttpRequest();
                                                 });

            // Then
            Assert.Equal(status,
                         result.StatusCode);
        }

        private static Browser CreateBrowser()
        {
            var bootstrapper = new Bootstrapper();
            var browser = new Browser(bootstrapper,
                                      to => to.Accept("application/json"));
            return browser;
        }

        private static dynamic CreateExpectedResponseForMiller()
        {
            const string json = "{" +
                                "\"Id\":1," +
                                "\"FirstName\":\"Peter\"," +
                                "\"Surname\":\"Smith\"," +
                                "\"DateOfBirth\":\"30/06/2010\"," +
                                "\"Sex\":\"m\"," +
                                "\"Email\":\"p.smith@gmail.com\"" +
                                "}";

            return XUnitPersonsHelper.ToDynamic(json);
        }

        private dynamic CreateExpectedJsonStringForList()
        {
            const string json = "[" +
                                "{\"Id\":1,\"FirstName\":\"Peter\",\"Surname\":\"Smith\",\"DateOfBirth\":\"30/06/2010\",\"Sex\":\"m\",\"Email\":\"p.smith@gmail.com\"}," +
                                "{\"Id\":2,\"FirstName\":\"Tim\",\"Surname\":\"Mayer\",\"DateOfBirth\":\"30/06/2000\",\"Sex\":\"m\",\"Email\":\"t.mayer@gmail.com\"}" +
                                "]";

            return XUnitPersonsHelper.ToDynamic(json);
        }

        private dynamic CreateExpectedResponseForCreate()
        {
            string dateString = DateTime.Now.ToShortDateString();

            string jsonOne = "{" +
                             "\"Id\": -1," +
                             "\"FirstName\": \"FirstName\"," +
                             "\"Surname\": null," +
                             "\"Sex\": null," +
                             "\"Email\": null,";

            string jsonTwo = "\"DateOfBirth\" : \"" + dateString + "\"}";

            string together = jsonOne + jsonTwo;

            return XUnitPersonsHelper.ToDynamic(together);
        }

        private dynamic CreatedExpectedDoctorFor(int id)
        {
            string dateString = DateTime.Now.ToShortDateString();

            string jsonOne = "{" +
                             "\"Id\": " + id + "," +
                             "\"FirstName\": \"FirstName\"," +
                             "\"Surname\": null," +
                             "\"Sex\": null," +
                             "\"Email\": null,";

            string jsonTwo = "\"DateOfBirth\" : \"" + dateString + "\"}";

            string together = jsonOne + jsonTwo;

            return XUnitPersonsHelper.ToDynamic(together);
        }

        private dynamic CreateDoctorToBeDeleted(Browser browser)
        {
            BrowserResponse result = browser.Post("/person/",
                                                  with =>
                                                  {
                                                      with.HttpRequest();
                                                  });

            dynamic actual = XUnitPersonsHelper.ToDynamic(result.Body.AsString());

            return actual;
        }

        private IPersonForResponse CreateModelForPutTest()
        {
            var model = new UpdatePersonModel
                        {
                            FirstName = "Create",
                            Surname = "Test",
                            DateOfBirth = "1/01/2001",
                            Sex = "M",
                            Email = "Email"
                        };

            return model;
        }

        private dynamic CreateExpectedResponseForPutTest()
        {
            const string json = "{" +
                                "\"FirstName\":\"Create\"," +
                                "\"Surname\":\"Test\"," +
                                "\"Id\":-1," +
                                "\"DateOfBirth\" : \"1/01/2001\"," +
                                "\"Sex\" : \"M\"," +
                                "\"Email\" : \"Email\"" +
                                "}";

            return XUnitPersonsHelper.ToDynamic(json);
        }

        private IPersonForResponse CreateModelForUpdate(dynamic person)
        {
            int id = Convert.ToInt32(person [ "Id" ].Value);

            var model = new UpdatePersonModel
                        {
                            Id = id,
                            FirstName = "FirstName Update",
                            Surname = "Surname Update",
                            DateOfBirth = "11/11/2011",
                            Sex = "F",
                            Email = "Email Updated"
                        };

            return model;
        }

        private dynamic CreatedExpectedDoctorForUpdate(int personId)
        {
            string json = "{" +
                          "\"Id\": " + personId + "," +
                          "\"FirstName\": \"FirstName Update\"," +
                          "\"Surname\": \"Surname Update\"," +
                          "\"Sex\": \"F\"," +
                          "\"Email\": \"Email Updated\"," +
                          "\"DateOfBirth\" : \"11/11/2011\"" +
                          "}";

            string together = json;

            return XUnitPersonsHelper.ToDynamic(together);
        }

        private void DeleteDoctorById(long id)
        {
            Browser browser = CreateBrowser();
            BrowserResponse result = browser.Delete("/person/" + id,
                                                    with =>
                                                    {
                                                        with.HttpRequest();
                                                    });

            Assert.Equal(HttpStatusCode.OK,
                         result.StatusCode);
        }

        private class UpdatePersonModel : IPersonForResponse
        {
            public UpdatePersonModel()
            {
                FirstName = string.Empty;
            }

            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string DateOfBirth { get; set; }
            public string Sex { get; set; }
            public string Email { get; set; }
            public int Id { get; set; }
        }
    }

    public static class XUnitPersonsHelper
    {
        public static void AssertPersonIgnoreId(dynamic expected,
                                                dynamic actual)
        {
            Console.WriteLine("Comparing persons with id {0} and {1}...",
                              expected [ "Id" ].Value,
                              actual [ "Id" ].Value);

            Assert.True(expected [ "FirstName" ].Value == actual [ "FirstName" ].Value,
                        "FirstName");
            Assert.True(expected [ "Surname" ].Value == actual [ "Surname" ].Value,
                        "Surname");
            Assert.True(expected [ "DateOfBirth" ].Value == actual [ "DateOfBirth" ].Value,
                        "DateOfBirth");
            Assert.True(expected [ "Sex" ].Value == actual [ "Sex" ].Value,
                        "Sex");
            Assert.True(expected [ "Email" ].Value == actual [ "Email" ].Value,
                        "Email");
        }

        public static void AssertPerson(dynamic expected,
                                        dynamic actual)
        {
            Console.WriteLine("Comparing persons with id {0} and {1}...",
                              expected [ "Id" ].Value,
                              actual [ "Id" ].Value);

            Assert.True(expected [ "Id" ].Value == actual [ "Id" ].Value,
                        "Id");
            Assert.True(expected [ "FirstName" ].Value == actual [ "FirstName" ].Value,
                        "FirstName");
            Assert.True(expected [ "Surname" ].Value == actual [ "Surname" ].Value,
                        "Surname");
            Assert.True(expected [ "DateOfBirth" ].Value == actual [ "DateOfBirth" ].Value,
                        "DateOfBirth");
            Assert.True(expected [ "Sex" ].Value == actual [ "Sex" ].Value,
                        "Sex");
            Assert.True(expected [ "Email" ].Value == actual [ "Email" ].Value,
                        "Email");
        }

        public static void AssertDoctors(dynamic expected,
                                         dynamic actual)
        {
            var expectedList = new List <dynamic>();
            foreach ( dynamic expectedSlot in expected )
            {
                expectedList.Add(expectedSlot);
            }

            var actualList = new List <dynamic>();
            foreach ( dynamic actualSlot in actual )
            {
                actualList.Add(actualSlot);
            }

            Assert.True(expectedList.Count == actualList.Count,
                        "count");

            foreach ( dynamic expectedSlot in expectedList )
            {
                var expectedSlotId = ( int ) expectedSlot [ "Id" ].Value;

                object compareToSlot = GetDoctorWithId(actualList,
                                                       expectedSlotId);

                AssertPerson(expectedSlot,
                             compareToSlot);
            }
        }

        public static dynamic ToDynamic(string json)
        {
            dynamic data = JsonConvert.DeserializeObject(json);

            return data;
        }

        private static object GetDoctorWithId(IEnumerable <dynamic> list,
                                              int id)
        {
            return list.FirstOrDefault(slot => id == ( int ) slot [ "Id" ].Value);
        }

        public static string ToJson([NotNull] object instance)
        {
            return JsonConvert.SerializeObject(instance);
        }
    }
}