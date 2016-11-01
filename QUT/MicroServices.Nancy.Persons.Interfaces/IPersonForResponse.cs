using JetBrains.Annotations;

namespace MicroServices.Nancy.Persons.Interfaces
{
    public interface IPersonForResponse
    {
        int Id { get; set; }

        [NotNull]
        string FirstName { get; set; }

        string Surname { get; set; }
        string DateOfBirth { get; set; }
        string Sex { get; set; }
        string Email { get; set; }
    }
}