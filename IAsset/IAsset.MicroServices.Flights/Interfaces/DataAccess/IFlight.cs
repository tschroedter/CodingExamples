using System;
using IAsset.MicroServices.Common.DataAccess;

namespace IAsset.MicroServices.Flights.Interfaces.DataAccess
{
    public interface IFlight : IEntity
    {
        DateTime Departure { get; set; }
        DateTime Arrival { get; set; }
    }
}