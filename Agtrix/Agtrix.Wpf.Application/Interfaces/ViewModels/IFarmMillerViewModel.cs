using System;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Interfaces.ViewModels
{
    public interface IFarmMillerViewModel
        : IViewModel
    {
        Guid MillerId { get; set; }
        Guid FarmId { get; set; }
        string FieldsCode { get; set; }
        string FarmName { get; set; }
        DateTime Harvested { get; set; }
        FarmType FarmType { get; set; }
        string MillerName { get; set; }
    }
}