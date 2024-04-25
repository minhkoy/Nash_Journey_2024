using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment_Day1.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get => DateTime.Now.Year - DateOfBirth.Year; }
        public bool IsGraduated { get; set; }

        public override string ToString()
        {
            var result = 
                $"First name: {FirstName}, Last name: {LastName}, Gender: {Gender}, DateOfBirth: {DateOfBirth.ToString("HH:mm:ss dd/MM/yyyy")}, " +
                $"Phone number: {PhoneNumber}, Birth Place: {BirthPlace}, Age: {Age}, Is Graduated: {IsGraduated}";
            return result;
        }
    }
}
