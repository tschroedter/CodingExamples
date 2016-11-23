using System.Collections.Generic;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Services.Events
{
    public class MillersChangedEvent
    {
        public IEnumerable <IMiller> Millers { get; set; }
    }
}