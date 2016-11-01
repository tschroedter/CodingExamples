using System;

namespace Deswik.MyTasks.Domain
{
    public class DeswikDateTime : IDateTime
    {
        public DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }
    }
}