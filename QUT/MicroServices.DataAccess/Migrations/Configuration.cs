using System;
using System.Data.Entity.Migrations;
using MicroServices.DataAccess.Contexts;
using MicroServices.DataAccess.Entities;

namespace MicroServices.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration <PersonsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PersonsContext context)
        {
            SeedPersons(context);
        }

        private void SeedPersons(PersonsContext context)
        {
            var smith = new Person
                        {
                            FirstName = "Peter",
                            Surname = "Smith",
                            DateOfBirth = DateTime.Parse("2010-06-30"),
                            Sex = "m",
                            Email = "p.smith@gmail.com"
                        };

            context.Add(smith);

            var meier = new Person
                        {
                            FirstName = "Tim",
                            Surname = "Mayer",
                            DateOfBirth = DateTime.Parse("2000-06-30"),
                            Sex = "m",
                            Email = "t.mayer@gmail.com"
                        };

            context.Add(meier);
        }
    }
}