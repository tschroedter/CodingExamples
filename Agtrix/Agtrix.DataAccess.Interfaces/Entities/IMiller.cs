namespace Agtrix.DataAccess.Interfaces.Entities
{
    public interface IMiller
        : IEntity
    {
        string Name { get; set; }
        string Address { get; set; }
    }
}