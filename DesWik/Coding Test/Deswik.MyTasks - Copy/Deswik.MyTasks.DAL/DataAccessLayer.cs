using Deswik.MyTasks.Entities;
using System;
using System.Data.SqlClient;

namespace Deswik.MyTasks.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private const string Dbconn = "Data Source=localhost;Initial Catalog=mytasks; Integrated Security=SSPI;";

        public Company GetCompany(int companyId)
        {
            using (var conn = new SqlConnection(Dbconn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, FullTimeWorkHours FROM Company WHERE Id = " + companyId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Company()
                            {
                                Id = reader.GetInt32(0),
                                FullTimeWorkHours = reader.GetDouble(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public double? GetTasksTotalHours(int companyId, int employeeId)
        {
            using (var conn = new SqlConnection(Dbconn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT sum(EstimateHours) FROM Task WHERE employeeId = " + employeeId;
                    var result = cmd.ExecuteScalar();
                    if (result == null || Convert.IsDBNull(result))
                    {
                        return null;
                    }
                    else
                    {
                        return (double)result;
                    }
                }
            }
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            using (var conn = new SqlConnection(Dbconn))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, CompanyId, FTE FROM Employee WHERE Id = " + employeeId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Employee()
                            {
                                Id = reader.GetInt32(0),
                                CompanyId = reader.GetInt32(1),
                                FTE = reader.GetDouble(2)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
