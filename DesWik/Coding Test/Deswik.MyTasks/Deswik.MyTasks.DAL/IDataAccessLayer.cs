using Deswik.MyTasks.Entities;

namespace Deswik.MyTasks.DAL
{
    public interface IDataAccessLayer
    {
        Company GetCompany(int companyId);
        double? GetTasksTotalHours(int companyId, int employeeId);
        Employee GetEmployeeDetails(int employeeId);
    }
}