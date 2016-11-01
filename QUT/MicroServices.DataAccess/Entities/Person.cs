using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using MicroServices.DataAccess.Interfaces.Entities;

namespace MicroServices.DataAccess.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("Person")]
    public class Person : IPerson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string Surname { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(1)]
        public string Sex { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
    }
}