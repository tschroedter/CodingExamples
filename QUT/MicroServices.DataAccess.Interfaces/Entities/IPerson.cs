using System;

namespace MicroServices.DataAccess.Interfaces.Entities
{
    public interface IPerson : IEntity
    {
        string FirstName { get; set; }
        string Surname { get; set; }
        DateTime DateOfBirth { get; set; }
        string Sex { get; set; }
        string Email { get; set; }
    }
}