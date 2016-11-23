using System;

namespace Agtrix.DataAccess.Interfaces.Entities
{
    public interface IFarm
        : IEntity
    {
        string FieldsCode { get; set; }
        string Name { get; set; }
        DateTime Harvested { get; set; }
        FarmType FarmType { get; set; }
        Guid MillerId { get; set; }
    }
}