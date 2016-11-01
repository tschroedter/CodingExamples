using System;
using Deswik.MyTasks.DAL;
using Deswik.MyTasks.Domain;
using Deswik.MyTasks.Entities;
using NSubstitute;
using NUnit.Framework;

namespace Deswik.MyTasks.Tests
{
    // todo AutoDataNSubstitute
    [TestFixture]
    internal sealed class DomainTests
    {
        private const int EmployeeIdDoesNotMatter = -1;

        private IDataAccessLayer m_Dal;
        private Domain.Domain m_Sut;
        private Employee m_Employee;
        private Company m_Company;
        private IDateTime m_DateTime;

        [SetUp]
        public void Setup()
        {   
            m_Company = new Company
                        {
                            Id = 100,
                            FullTimeWorkHours = 8.0
                        };

            m_Employee = new Employee
                         {
                             Id = 200,
                             CompanyId = 100,
                             FTE = 1.0
                         };

            m_DateTime = Substitute.For <IDateTime>();
            m_Dal = Substitute.For <IDataAccessLayer>();
            m_Sut = new Domain.Domain(m_Dal,
                                      m_DateTime);
        }

        [Test]
        public void EstimatedFinishDate_ReturnsNull_ForUnknownEmployeeId()
        {
            // Arrange
            m_Dal.GetEmployeeDetails(Arg.Any <int>())
                 .Returns(( Employee ) null);

            // Act
            var actual = m_Sut.EstimatedFinishDate(EmployeeIdDoesNotMatter);

            // Assert
            Assert.IsNull(actual);
        }

        [Test]
        public void EstimatedFinishDate_ReturnsNull_ForTotalHoursIsNull()
        {
            // Arrange
            m_Dal.GetEmployeeDetails(m_Employee.Id)
                 .Returns(m_Employee);

            m_Dal.GetTasksTotalHours(m_Employee.CompanyId,
                                     m_Employee.Id)
                 .Returns((double?)null);

            // Act
            var actual = m_Sut.EstimatedFinishDate(m_Employee.Id);

            // Assert
            Assert.IsNull(actual);
        }

        [Theory]
        [TestCase("01/01/2000 12:00:00", "01/01/2000 00:00:00", 4.0)]
        [TestCase("02/01/2000 00:00:00", "01/01/2000 00:00:00", 8.0)]
        [TestCase("03/01/2000 00:00:00", "01/01/2000 00:00:00", 16.0)]
        public void EstimatedFinishDate_FinishDate_ForKnownEmployee(
            string expectedDateTime,
            string todayDateTime,
            double totalHours)
        {
            // Arrange
            var expected = DateTime.Parse(expectedDateTime);

            // todo use an IRepository
            m_Dal.GetEmployeeDetails(m_Employee.Id)
                 .Returns(m_Employee);

            m_Dal.GetTasksTotalHours(m_Employee.CompanyId,
                                     m_Employee.Id)
                 .Returns(totalHours);

            m_Dal.GetCompany(m_Employee.CompanyId)
                 .Returns(m_Company);

            m_DateTime.Today.Returns(DateTime.Parse(todayDateTime));

            // Act
            var actual = m_Sut.EstimatedFinishDate(m_Employee.Id);

            // Assert
            Assert.AreEqual(expected,
                            actual);
        }
    }
}
