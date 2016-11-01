using IAsset.MicroServices.FlightsAssignedToGates.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;

namespace IAsset.MicroServices.FlightsAssignedToGates.Nancy
{
    public class FlightsAssignedToGatesModule
        : NancyModule
    {
        public FlightsAssignedToGatesModule([NotNull] IFlightsAssignedToGatesRequestHandler handler)
            : base("/flightsassignedtogates")
        {
            Get [ "/" ] =
                parameters => handler.List();

            Get [ "/{id:int}" ] =
                parameters => handler.FlightsAssignedToGate(( int ) parameters.id);
        }
    }
}