using Person.Model.DTOs;
using Person.Model.DTOs.Common;
using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person.Service.Interfaces
{
    public interface IPersonService
    {
        PersonDTO Create(CreatePersonRequest person);
        List<PersonDTO> CreateRange(List<CreatePersonRequest> persons);
        PersonDTO? GetById(string id);
        List<PersonDTO> GetPagingPeople(GetPagingPeopleRequest request);
        IEnumerable<PersonDTO> GetAll();
        PersonDTO? Update(UpdatePersonRequest person);
        bool Delete(string id);
        bool DeleteRange(List<string> ids);
    }
}
