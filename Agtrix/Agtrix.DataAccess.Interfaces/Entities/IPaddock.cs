using System;

namespace Agtrix.DataAccess.Interfaces.Entities
{
    public interface IPaddock
        : IEntity
    {
        string FieldsCode { get; set; }
        float AreaInHectares { get; set; }
        Guid FarmId { get; set; }
    }
}