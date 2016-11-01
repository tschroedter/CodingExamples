using System.Diagnostics.CodeAnalysis;
using IAsset.MicroServices.Gates.Interfaces.DataAccess;

namespace IAsset.MicroServices.Gates.DataAccess
{
    [ExcludeFromCodeCoverage]
    public class Gate : IGate
    {
        public Gate()
        {
            Description = string.Empty;
        }

        public int Id { get; set; }
        public string Description { get; set; }
    }
}