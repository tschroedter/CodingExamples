using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deswik.MyTasks.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }

        /// <summary>
        /// employees full time equivelent - i.e 0.5 means working part time
        /// </summary>
        public double FTE { get; set; }
    }
}
