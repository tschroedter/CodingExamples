using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using MicroServices.Nancy.Persons.Interfaces;
using Nancy;
using Nancy.ModelBinding;

namespace MicroServices.Nancy.Persons
{
    [ExcludeFromCodeCoverage]
    public class PersonsModule
        : NancyModule
    {
        public PersonsModule([NotNull] IRequestHandler handler)
            : base("/person")
        {
            Get [ "/" ] =
                parameters => handler.List();

            Get [ "/{id:int}" ] =
                parameters => handler.FindById(( int ) parameters.id);

            Post [ "/" ] =
                parameters => handler.Save(this.Bind <PersonForResponse>());

            Put [ "/" ] =
                parameters => handler.Save(this.Bind <PersonForResponse>());

            Delete [ "/{id:int}" ] =
                parameters => handler.DeleteById(( int ) parameters.id);
        }
    }
}