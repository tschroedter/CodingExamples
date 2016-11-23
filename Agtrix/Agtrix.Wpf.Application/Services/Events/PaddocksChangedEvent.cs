using System.Collections.Generic;
using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Services.Events
{
    public class PaddocksChangedEvent
    {
        public IEnumerable <IPaddock> Paddocks { get; set; }
    }
}