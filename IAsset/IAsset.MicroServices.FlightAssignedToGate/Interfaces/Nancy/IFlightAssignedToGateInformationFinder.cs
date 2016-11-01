using System.Collections.Generic;
using IAsset.MicroServices.Common.Nancy;
using IAsset.MicroServices.FlightAssignedToGate.Interfaces.DataAccess;

namespace IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy
{
    public interface IFlightAssignedToGateInformationFinder
        : IInformationFinder <IFlightAssignedToGate>
    {
        IEnumerable <IFlightAssignedToGate> FlightsAssignedToGate(int gateId);
    }
}