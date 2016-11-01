using System;
using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Flights.Interfaces.DataAccess;

namespace IAsset.MicroServices.Flights.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class Flight : IFlight
    {
        public int Id { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}