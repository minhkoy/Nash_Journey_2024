using AutoMapper;
using Person.Model.DTOs;
using Person.Model.DTOs.Common;
using Person.Model.Entities;
using Person.Model.Repositories;
using Person.Model.Requests;
using Person.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Person.Service.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper; 
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public PersonDTO Create(CreatePersonRequest person)
        {
            if (person is null)// || !person.GetValidationResult())
            {
                throw new ValidationException("The request model must not be empty!");
            }
            ThePerson newPerson = _mapper.Map<ThePerson>(person);
            _personRepository.Add(newPerson);
            return _mapper.Map<PersonDTO>(newPerson);
        }
        public List<PersonDTO> CreateRange(List<CreatePersonRequest> persons)
        {
            List<ThePerson> newPeople = new();
            persons.ForEach(person => newPeople.Add(new ThePerson
            {
                BirthPlace = person.BirthPlace,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth!.Value,
                Gender = person.Gender!.Value,
            }));
            _personRepository.AddRange(newPeople);
            return _mapper.Map<List<PersonDTO>>(newPeople);
        }
        public PersonDTO? GetById(string id)
        {
            var person = _personRepository.GetById(id);
            return _mapper.Map<PersonDTO>(person);
        }
        public IEnumerable<PersonDTO> GetAll()
        {
            var peopleList = _personRepository.GetAll();
            return _mapper.Map<List<PersonDTO>>(peopleList);
        }

        public List<PersonDTO> GetPagingPeople(GetPagingPeopleRequest request)
        {
            var peopleList = _personRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                peopleList = peopleList.Where(person => person.FullName.Contains(request.Name, StringComparison.CurrentCulture));
            }
            if (request.Gender.HasValue)
            {
                peopleList = peopleList.Where(person => person.Gender == request.Gender.Value);
            }
            if (!string.IsNullOrWhiteSpace(request.BirthPlace))
            {
                peopleList = peopleList.Where(person => person.BirthPlace.Contains(request.BirthPlace, StringComparison.CurrentCultureIgnoreCase));
            }
            peopleList = peopleList
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            return _mapper.Map <List<PersonDTO>>(peopleList.ToList());
        }

        public PersonDTO? Update(UpdatePersonRequest person)
        {
            if (person is null || string.IsNullOrEmpty(person.Id))
            {
                throw new ValidationException("Validation fails. Id is required.");
            }
            ThePerson updatePerson = new()
            {
                Id = person.Id,
                BirthPlace = person.BirthPlace,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth!.Value,
                Gender = person.Gender!.Value,
            };
            _personRepository.Update(updatePerson);
            return _mapper.Map<PersonDTO>(updatePerson);
        }
        public bool Delete(string id)
        {
            return _personRepository.Delete(id);
        }

        public bool DeleteRange(List<string> ids)
        {
            return _personRepository.DeleteRange(ids);
        }
    }
}
