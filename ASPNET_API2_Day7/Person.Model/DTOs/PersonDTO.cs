using AutoMapper;
using Person.Model.Entities;
using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.DTOs
{
    [AutoMap(typeof(ThePerson))]
    public class PersonDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string BirthPlace { get; set; }
        public string FullName { get => string.Concat(FirstName," ", LastName); }
        public PersonDTO() { }
    }
}
