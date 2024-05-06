using ASPNET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET_MVC.Business.Interfaces
{
    public interface IPersonService
    {
        List<Person> GetPeopleByGender(string gender);
        Person? GetOldestPersonByAge();
        Person? GetOldestPersonByDob();
        List<string> GetOnlyFullnameList();
        List<Person> GetPeopleWithBirthYear(string comparer, int year);
        Person? GetFirstPersonByBirthPlace(string birthPlace);
        MemoryStream ExportPeopleListToExcel();
    }
}
