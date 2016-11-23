using System;
using System.Collections.Generic;
using Agtrix.Wpf.Application.Dto;

namespace Agtrix.Wpf.Application.Services.Events
{
    public class FarmsMillersChangedEvent
    {
        public IEnumerable <FarmMillerDto> FarmMillerDtos { get; set; }
        public Guid SelectedFarmId { get; set; }
    }
}