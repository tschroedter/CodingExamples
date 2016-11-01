using System;
using System.Collections.Generic;
using System.Linq;
using MicroServices.DataAccess.Entities;
using MicroServices.DataAccess.Interfaces.Entities;
using MicroServices.DataAccess.Interfaces.Repositories;
using MicroServices.Nancy.Persons.Interfaces;
using Selkie.Windsor;

namespace MicroServices.Nancy.Persons
{
    [ProjectComponent(Lifestyle.Transient)]
    public class InformationFinder : IInformationFinder
    {
        public InformationFinder(IPersonsRepository repository)
        {
            Repository = repository;
        }

        private IPersonsRepository Repository { get; set; }

        public IPersonForResponse FindById(int id)
        {
            IPerson person = Repository.FindById(id);

            return person == null
                       ? null
                       : new PersonForResponse(person);
        }

        public IEnumerable <IPersonForResponse> List()
        {
            IEnumerable <IPerson> persons = Repository.All;

            PersonForResponse[] doctorsWithNoSlots = persons.Select(doctor => new PersonForResponse(doctor))
                                                            .ToArray();

            return doctorsWithNoSlots;
        }

        public IPersonForResponse Delete(int id)
        {
            IPerson person = Repository.Delete(id);

            return person == null
                       ? null
                       : new PersonForResponse(person);
        }

        public IPersonForResponse Save(IPersonForResponse person)
        {
            IPerson toBeUpdated = ToPerson(person);

            Repository.Save(toBeUpdated);

            return new PersonForResponse(toBeUpdated);
        }

        private IPerson ToPerson(IPersonForResponse person)
        {
            string firstName = TextOrDefault(person.FirstName,
                                             "FirstName");
            DateTime dateOfBirth = DateOrDefault(person.DateOfBirth,
                                                 DateTime.Now);

            IPerson instance = new Person
                               {
                                   Id = person.Id,
                                   FirstName = firstName,
                                   Surname = person.Surname,
                                   DateOfBirth = dateOfBirth,
                                   Sex = person.Sex,
                                   Email = person.Email
                               };

            return instance;
        }

        private static string TextOrDefault(string text,
                                            string defaultText)
        {
            return string.IsNullOrEmpty(text)
                       ? defaultText
                       : text;
        }

        private DateTime DateOrDefault(string dateOfBirth,
                                       DateTime now)
        {
            if ( string.IsNullOrEmpty(dateOfBirth) )
            {
                return now;
            }

            DateTime dateTime;

            if ( !DateTime.TryParse(dateOfBirth,
                                    out dateTime) )
            {
                return now; // todo should throw exception
            }

            return dateTime;
        }
    }
}