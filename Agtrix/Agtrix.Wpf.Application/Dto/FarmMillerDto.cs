using System;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Dto
{
    public class FarmMillerDto
    {
        public Guid FarmId { get; set; }
        public string FieldsCode { get; set; }
        public string FarmName { get; set; }
        public DateTime Harvested { get; set; }
        public FarmType FarmType { get; set; }
        public Guid MillerId { get; set; }
        public string MillerName { get; set; }
    }
}