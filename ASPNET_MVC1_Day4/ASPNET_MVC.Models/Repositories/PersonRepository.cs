using ASPNET_MVC.Models;
using ASPNET_MVC.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> _peopleList = new List<Person>();
        public PersonRepository()
        {
            for (int i = 1; i <= 20; i++)
            {
                _peopleList.Add(new()
                {
                    FirstName = $"First name {i}",
                    LastName = $"Last name {i}",
                    BirthPlace = i < 15 ? $"Birth place {i}" : "Ha Noi",
                    DateOfBirth = DateTime.Today.AddYears(-10 - i),
                    Gender = i % 2 == 0 ? ConstantExtensions.Genders.Male : ConstantExtensions.Genders.Female,
                    IsGraduated = i % 3 == 0,
                    PhoneNumber = $"03456789{i}"
                });
            }
        }

        public IEnumerable<Person> GetEnumerable()
        {
            return _peopleList.AsEnumerable();
        }
        public void Add(Person person)
        {
            _peopleList.Add(person);
        }

        public void Delete(Person person)
        {
            _peopleList.Remove(person);
        }

        public Person Get(int id)
        {
            return new Person();
        }

        public void Update(Person person)
        {
            
        }
    }
}
