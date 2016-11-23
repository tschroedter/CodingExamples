using System;
using Agtrix.DataAccess.Interfaces.Entities;
using Agtrix.Wpf.Application.Dto;
using Agtrix.Wpf.Application.Interfaces.ViewModels;
using Caliburn.Micro;
using JetBrains.Annotations;

namespace Agtrix.Wpf.Application.ViewModels
{
    public class FarmMillerViewModel
        : PropertyChangedBase,
          IFarmMillerViewModel
    {
        public FarmMillerViewModel(
            [NotNull] FarmMillerDto dto)
        {
            MillerId = dto.MillerId;
            FarmId = dto.FarmId;
            FieldsCode = dto.FieldsCode;
            FarmName = dto.FarmName;
            Harvested = dto.Harvested;
            FarmType = dto.FarmType;
            MillerName = dto.MillerName;
        }

        public Guid MillerId { get; set; }
        public Guid FarmId { get; set; }
        public string FieldsCode { get; set; }
        public string FarmName { get; set; }
        public DateTime Harvested { get; set; }
        public FarmType FarmType { get; set; }
        public string MillerName { get; set; }
    }
}