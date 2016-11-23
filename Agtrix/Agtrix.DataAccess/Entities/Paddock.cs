using System;
using System.Diagnostics;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.DataAccess.Entities
{
    [DebuggerDisplay("Id: {Id}, FarmId: {FarmId}, FieldsCode: {FieldsCode}, AreaInHectares: {AreaInHectares}")]
    public class Paddock
        : BaseEntity,
          IPaddock
    {
        public Guid FarmId { get; set; }
        public string FieldsCode { get; set; }
        public float AreaInHectares { get; set; }
    }
}