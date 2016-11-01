using System;
using Deswik.MyTasks.DAL;
using Deswik.MyTasks.Domain;

namespace Deswik.MyTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter employe id:");
            var employeeId = Console.ReadLine();
            int id = Convert.ToInt32(employeeId);

            var datetime = new DeswikDateTime();
            var dal = new DataAccessLayer();
            var domain = new Domain.Domain(dal,
                                           datetime);

            var date = domain.EstimatedFinishDate(id);

            if (date != null)
            {

                Console.WriteLine("Employee will be finished all her tasks on: " + date.Value.ToShortDateString());
            } else
            {
                Console.WriteLine("Employee has no tasks");
            }

            Console.ReadLine();
        }
    }
}
