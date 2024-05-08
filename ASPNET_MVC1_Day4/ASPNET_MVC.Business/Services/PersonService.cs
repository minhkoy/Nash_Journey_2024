using ASPNET_MVC.Business.Interfaces;
using ASPNET_MVC.Models;
using ASPNET_MVC.Models.Helpers;
using ASPNET_MVC.Models.Repositories;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OfficeOpenXml.ExcelErrorValue;

namespace ASPNET_MVC.Business.Services
{
    public class PersonService : IPersonService
    {
        public readonly IPersonRepository _personRepository;
        public readonly IExportToExcelService _exportToExcelService;
        public PersonService(IPersonRepository personRepository, IExportToExcelService exportToExcelService)
        {
            _personRepository = personRepository;
            _exportToExcelService = exportToExcelService;
        }

        public List<Person> GetListPeople(int page = 0, int pageSize = 10)
        {
            if (page == 0)
            {
                return _personRepository.GetEnumerable().ToList();
            }
            return _personRepository.GetEnumerable()
                .Skip((page - 1)*pageSize)
                .Take(pageSize)
                .ToList();
        }
        public List<Person> GetPeopleByGender(string gender)
        {
            return _personRepository.GetEnumerable().Where(person => string.Equals(person.Gender, gender)).ToList();
        }

        public Person? GetOldestPersonByAge()
        {
            return _personRepository.GetEnumerable().MaxBy(person => person.Age);
        }

        public Person? GetOldestPersonByDob()
        {
            return _personRepository.GetEnumerable().MinBy(person => person.DateOfBirth);
        }

        public List<string> GetOnlyFullnameList()
        {
            return _personRepository.GetEnumerable().Select(person => string.Concat(person.LastName, " ", person.FirstName)).ToList();
        }

        public List<Person> GetPeopleWithBirthYear(string comparer, int year)
        {
            switch (comparer)
            {
                case ConstantExtensions.Comparer.GreaterThan:
                    return _personRepository.GetEnumerable().Where(person => person.DateOfBirth.Year > year).ToList();
                case ConstantExtensions.Comparer.LessThan:
                    return _personRepository.GetEnumerable().Where(person => person.DateOfBirth.Year < year).ToList();
                case ConstantExtensions.Comparer.Equal:
                    return _personRepository.GetEnumerable().Where(person => person.DateOfBirth.Year == year).ToList();
                default:
                    return [];
            }
        }

        public Person? GetFirstPersonByBirthPlace(string birthPlace)
        {
            return _personRepository.GetEnumerable().FirstOrDefault(person => string.Equals(person.BirthPlace, birthPlace));
        }

        public MemoryStream ExportPeopleListToExcel()
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                var ws = pck.Workbook.Worksheets.Add($"PeopleList {DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy")}");
                ws.Cells["A2"].LoadFromCollection(_personRepository.GetEnumerable(),  PrintHeaders: true);
                ws.Cells["A1"].Value = "PEOPLE LIST";
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Columns[5].Style.Numberformat.Format = "dd/MM/yyyy";
                List<string> isGraduatedColumnValues = new List<string>();
                foreach (var person in _personRepository.GetEnumerable())
                {
                    isGraduatedColumnValues.Add(person.IsGraduated ? "Yes" : "No");
                }
                ws.Cells["I3"].LoadFromCollection(isGraduatedColumnValues);
                ws.Rows[2].Style.Font.Bold = true;
                ws.Cells.AutoFitColumns();
                var stream = new MemoryStream();
                pck.SaveAs(stream);

                return stream;
            }
        }

        public Person Create(Person person)
        {
            _personRepository.Add(person);
            return person;
        }

        public Person GetById(Guid id)
        {
            return _personRepository.Get(id);
        }
        public Person Update(Person person)
        {
            _personRepository.Update(person);
            return person;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var person = _personRepository.Get(id);
                if (person is null)
                {
                    return false;
                }
                return _personRepository.Delete(person);
            }
            catch (Exception)
            {
                //
                // Code for handling exceptions (logging, notifying, etc.)
                //
                return false;
            }
        }
    }
}
