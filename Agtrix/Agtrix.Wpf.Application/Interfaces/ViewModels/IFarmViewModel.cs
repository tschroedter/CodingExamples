using System;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Interfaces.ViewModels
{
    public interface IFarmViewModel
        : IViewModel
    {
        string FarmName { get; set; }
        string FieldsCode { get; set; }
        FarmType FarmType { get; set; }
        DateTime Harvested { get; set; }
        string MillerName { get; set; }
        Guid MillerId { get; set; }
        Guid FarmId { get; set; }
        void Apply();
    }
}