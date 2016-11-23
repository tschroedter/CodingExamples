using Agtrix.DataAccess.Interfaces.Entities;

namespace Agtrix.Wpf.Application.Services.Events
{
    public class FarmSaveEvent
    {
        public IFarm Farm { get; set; }
    }
}