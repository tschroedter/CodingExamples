using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using MicroServices.Common.Tests;
using MicroServices.Nancy.Persons.Interfaces;
using Nancy;
using NSubstitute;
using NSubstitute.Core;
using Xunit;
using Xunit.Extensions;

namespace MicroServices.Nancy.Persons.Tests
{
    public sealed class RequestHandlerTests
    {
        // todo don't know how to get content from Response object, 
        // but integration test cover this
        private const int DoesNotMatter = -1;

        [Fact]
        public void List_ReturnsResponse_WhenCalled()
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.List().Returns(CreateList);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.List();

            // Assert
            Assert.Equal(HttpStatusCode.OK,
                         actual.StatusCode);
        }

        [Theory]
        [AutoNSubstituteData]
        public void Save_ReturnsStatusOK_WhenCalled([NotNull] IPersonForResponse toBeCreated,
                                                    [NotNull] IPersonForResponse created)
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.Save(toBeCreated).Returns(created);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.Save(toBeCreated);

            // Assert
            Assert.Equal(HttpStatusCode.OK,
                         actual.StatusCode);
        }

        [Theory]
        [AutoNSubstituteData]
        public void DeleteById_ReturnsResponse_WhenCalled([NotNull] IPersonForResponse doctor)
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.Delete(doctor.Id).Returns(doctor);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.DeleteById(doctor.Id);

            // Assert
            Assert.Equal(HttpStatusCode.OK,
                         actual.StatusCode);
        }

        [Fact]
        public void DeleteById_ReturnsResponse_ForAddFailed()
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.Delete(DoesNotMatter).Returns(( IPersonForResponse ) null);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.DeleteById(DoesNotMatter);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound,
                         actual.StatusCode);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsResponse_ForKnownId([NotNull] IPersonForResponse doctor)
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.FindById(doctor.Id).Returns(doctor);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.FindById(doctor.Id);

            // Assert
            Assert.Equal(HttpStatusCode.OK,
                         actual.StatusCode);
        }

        [Theory]
        [AutoNSubstituteData]
        public void FindById_ReturnsResponse_ForUnknownId()
        {
            // Arrange
            var finder = Substitute.For <IInformationFinder>();
            finder.FindById(DoesNotMatter).Returns(( IPersonForResponse ) null);
            RequestHandler sut = CreateSut(finder);

            // Act
            Response actual = sut.FindById(DoesNotMatter);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound,
                         actual.StatusCode);
        }

        private IQueryable <IPersonForResponse> CreateList(CallInfo arg)
        {
            var list = new Collection <IPersonForResponse>
                       {
                           Substitute.For <IPersonForResponse>(),
                           Substitute.For <IPersonForResponse>()
                       };


            return list.AsQueryable();
        }

        private RequestHandler CreateSut(IInformationFinder finder)
        {
            return new RequestHandler(finder);
        }
    }
}