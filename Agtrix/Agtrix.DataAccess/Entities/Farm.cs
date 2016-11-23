using System;
using System.Diagnostics;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.DataAccess.Entities
{
    [DebuggerDisplay("Name: {Name}, Id: {Id}, MillerId: {MillerId}")]
    public class Farm
        : BaseEntity,
          IFarm
    {
        public string FieldsCode { get; set; }
        public string Name { get; set; }
        public DateTime Harvested { get; set; }
        public FarmType FarmType { get; set; }
        public Guid MillerId { get; set; }
    }
}