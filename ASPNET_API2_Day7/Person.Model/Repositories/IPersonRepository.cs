using Person.Model.DTOs;
using Person.Model.Entities;
using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Person.Model.Repositories
{
    public interface IPersonRepository
    {
        ThePerson Add(ThePerson person);
        List<ThePerson> AddRange(List<ThePerson> peopleList);
        ThePerson? GetById(string id);
        IEnumerable<ThePerson> GetAll();
        List<ThePerson> GetPaging(int page, int pageSize);
        ThePerson? Update(ThePerson person);
        bool Delete(string id);
        bool DeleteRange(List<string> ids);
    }
}
