using Person.Model.DTOs;
using Person.Model.Entities;
using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person.Model.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private List<ThePerson> _personList = new();
        public PersonRepository()
        {
            for (int i = 1; i <= 20; i++)
            {
                _personList.Add(new()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    FirstName = $"First name {i}",
                    LastName = $"Last name {i}",
                    BirthPlace = i < 15 ? $"Birth place {i}" : "Ha Noi",
                    DateOfBirth = DateTime.Today.AddYears(-10 - i),
                    Gender = (Gender)(i % 4),
                });
            }
        }

        public ThePerson Add(ThePerson newPerson)
        {
            _personList.Add(newPerson);
            return newPerson;
        }

        public List<ThePerson> AddRange(List<ThePerson> persons)
        {
            _personList.AddRange(persons);
            return persons;
        }

        public bool Delete(string id)
        {
            var personToDelete = _personList.FirstOrDefault(t => string.Equals(t.Id, id));
            if (personToDelete is null)
            {
                return false;
            }
            _personList.Remove(personToDelete);
            return true;
        }

        public ThePerson? GetById(string id)
        {
            var person = _personList.FirstOrDefault(t => string.Equals(t.Id, id));
            if (person is null)
            {
                return null;
            }
            return person;
        }

        public IEnumerable<ThePerson> GetAll()
        {
            return _personList.AsEnumerable();
        }

        public List<ThePerson> GetPaging(int pageIndex, int pageSize)
        {
            return _personList
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ThePerson? Update(ThePerson person)
        {
            var personToUpdate = _personList.FirstOrDefault(t => string.Equals(t.Id, person.Id));
            if (personToUpdate is null)
            {
                return null;
            }
            personToUpdate = person;
            return personToUpdate;
        }

        public bool DeleteRange(List<string> ids)
        {
            List<ThePerson> personsToDelete = _personList.Where(t => ids.Contains(t.Id)).ToList();
            if (personsToDelete.Count != ids.Count)
            {
                return false;
            }
            List<ThePerson> originalList = new();
            _personList.CopyTo(originalList.ToArray());
            _personList = _personList.Except(personsToDelete).ToList();
            if (_personList.Count == originalList.Count - personsToDelete.Count)
            {
                return true;
            }
            _personList = originalList;
            return false;
        }

    }
}
