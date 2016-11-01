using IAsset.MicroServices.FlightAssignedToGate.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Nancy.ModelBinding;

// ReSharper disable ImplicitlyCapturedClosure

namespace IAsset.MicroServices.FlightAssignedToGate.Nancy
{
    public class FlightAssignedToGateModule
        : NancyModule
    {
        public FlightAssignedToGateModule([NotNull] IFlightAssignedToGateRequestHandler handler)
            : base("/flightassignedtogate")
        {
            Get [ "/" ] =
                parameters => handler.List();

            Get [ "/{id:int}" ] =
                parameters => handler.FindById(( int ) parameters.id);

            Post [ "/" ] =
                parameters => handler.Save(this.Bind <DataAccess.FlightAssignedToGate>()); // todo binding doesn't work

            Put [ "/" ] =
                parameters => handler.Save(this.Bind <DataAccess.FlightAssignedToGate>());

            Delete [ "/{id:int}" ] =
                parameters => handler.DeleteById(( int ) parameters.id);
        }
    }
}