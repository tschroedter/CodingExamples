using IAsset.MicroServices.Gates.DataAccess;
using IAsset.MicroServices.Gates.Interfaces.Nancy;
using JetBrains.Annotations;
using Nancy;
using Nancy.ModelBinding;

// ReSharper disable ImplicitlyCapturedClosure

namespace IAsset.MicroServices.Gates.Nancy
{
    public class GatesModule
        : NancyModule
    {
        public GatesModule([NotNull] IGatesRequestHandler handler)
            : base("/gates")
        {
            Get [ "/" ] =
                parameters => handler.List();

            Get [ "/{id:int}" ] =
                parameters => handler.FindById(( int ) parameters.id);

            Post [ "/" ] =
                parameters => handler.Save(this.Bind <Gate>()); // todo binding doesn't work

            Put [ "/" ] =
                parameters => handler.Save(this.Bind <Gate>());

            Delete [ "/{id:int}" ] =
                parameters => handler.DeleteById(( int ) parameters.id);
        }
    }
}