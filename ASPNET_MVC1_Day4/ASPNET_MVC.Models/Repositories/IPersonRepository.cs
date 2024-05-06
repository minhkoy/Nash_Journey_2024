using ASPNET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetEnumerable();
        void Add(Person person);
        void Delete(Person person);
        void Update(Person person);
        Person Get(int id);
    }
}
