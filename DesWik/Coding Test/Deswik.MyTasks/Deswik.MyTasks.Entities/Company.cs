using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deswik.MyTasks.Entities
{
    public class Company
    {
        public int Id { get; set; }

        /// <summary>
        /// how many hours an employee should work each day for this company.
        /// these employees work every day and do not have days off!
        /// </summary>
        public double FullTimeWorkHours { get; set; }
    }
}
