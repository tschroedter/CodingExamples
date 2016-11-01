using JetBrains.Annotations;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.Nancy.Persons.Interfaces;

namespace MicroServices.Nancy.Persons
{
    public class PersonForResponse : IPersonForResponse
    {
        public PersonForResponse()
        {
            Id = 0;
            FirstName = string.Empty;
        }

        public PersonForResponse([NotNull] IPerson person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            Surname = person.Surname;
            DateOfBirth = person.DateOfBirth.ToShortDateString(); // todo not perfect
            Sex = person.Sex;
            Email = person.Email;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
    }
}