using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MicroServices.DataAccess.Entities;
using MicroServices.DataAccess.Interfaces.Contexts;
using MicroServices.DataAccess.Interfaces.Entities;
using Selkie.Windsor;

namespace MicroServices.DataAccess.Contexts
{
    [ExcludeFromCodeCoverage]
    [ProjectComponent(Lifestyle.Transient)]
    public class PersonsContext
        : DbContext,
          IPersonsContext
    {
        public PersonsContext()
            : base("QUT.Application")
        {
        }

        public DbSet <Person> DbSetPersons { get; set; }

        public IQueryable <IPerson> Persons()
        {
            return DbSetPersons;
        }

        public IPerson Delete(int id)
        {
            IPerson instance = DbSetPersons.Find(id);

            if ( instance == null )
            {
                return null;
            }

            Remove(instance);
            SaveChanges();

            return instance;
        }

        public void Remove(IPerson day)
        {
            Person instance = ConvertToPerson(day);

            DbSetPersons.Remove(instance);
        }

        public IPerson Find(int id)
        {
            return DbSetPersons.Find(id);
        }

        public void Add(IPerson person)
        {
            Person instance = ConvertToPerson(person);

            DbSetPersons.Add(instance);
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public void SetStateForSlot(IPerson person,
                                    EntityState modified)
        {
            Person instance = ConvertToPerson(person);

            Entry(instance).State = EntityState.Modified;
        }

        private Person ConvertToPerson(IPerson person)
        {
            var instance = person as Person;

            if ( instance == null )
            {
                throw new ArgumentException("Provided 'person' instance is not a Person!",
                                            "person");
            }

            return instance;
        }
    }
}