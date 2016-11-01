using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deswik.MyTasks.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int EmployeeeId { get; set; }
        public double EstimateHours { get; set; }
    }
}
