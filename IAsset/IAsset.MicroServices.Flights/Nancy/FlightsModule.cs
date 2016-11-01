using IAsset.MicroServices.Flights.DataAccess;
using IAsset.MicroServices.Flights.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Nancy.ModelBinding;

// ReSharper disable ImplicitlyCapturedClosure

namespace IAsset.MicroServices.Flights.Nancy
{
    public class FlightsModule
        : NancyModule
    {
        public FlightsModule([NotNull] IFlightsRequestHandler handler)
            : base("/flights")
        {
            Get [ "/" ] =
                parameters => handler.List();

            Get [ "/{id:int}" ] =
                parameters => handler.FindById(( int ) parameters.id);

            Post [ "/" ] =
                parameters => handler.Save(this.Bind <Flight>()); // todo binding doesn't work

            Put [ "/" ] =
                parameters => handler.Save(this.Bind <Flight>());

            Delete [ "/{id:int}" ] =
                parameters => handler.DeleteById(( int ) parameters.id);
        }
    }
}