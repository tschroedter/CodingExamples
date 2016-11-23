using System.Diagnostics;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.DataAccess.Entities
{
    [DebuggerDisplay("Name: {Name}, Id: {Id}, Address: {Address}")]
    public class Miller
        : BaseEntity,
          IMiller
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}