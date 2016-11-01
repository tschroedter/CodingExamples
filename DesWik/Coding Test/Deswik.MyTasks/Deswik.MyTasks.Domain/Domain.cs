using System;
using Deswik.MyTasks.DAL;
using Deswik.MyTasks.Entities;
using JetBrains.Annotations;

namespace Deswik.MyTasks.Domain
{
    public class Domain
    {
        private readonly IDataAccessLayer m_DataAccessLayer;
        private readonly IDateTime m_Datetime;

        public Domain([NotNull] IDataAccessLayer dataAccessLayer,
                      [NotNull] IDateTime datetime)
        {
            m_DataAccessLayer = dataAccessLayer;
            m_Datetime = datetime;
        }

        public DateTime? EstimatedFinishDate(int employeeId)
        {
            Employee employee = m_DataAccessLayer.GetEmployeeDetails(employeeId);

            if ( employee == null )
            {
                return null;
            }

            double? totalHours = m_DataAccessLayer.GetTasksTotalHours(employee.CompanyId,
                                                                      employee.Id);

            if ( totalHours == null )
            {
                return null;
            }

            DateTime finishDate = m_Datetime.Today;

            double employeeHours = totalHours.Value * employee.FTE;

            Company company = m_DataAccessLayer.GetCompany(employee.CompanyId);
            double days = employeeHours / company.FullTimeWorkHours;

            finishDate = finishDate.AddDays(days);

            return finishDate;
        }
    }
}