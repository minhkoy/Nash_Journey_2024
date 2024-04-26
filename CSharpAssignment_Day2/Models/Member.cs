using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment_Day2.Models
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

        public Member() { }
        public Member(string firstName, string lastName, string gender, DateTime dateOfBirth, string phoneNumber, string birthPlace, int age, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }

        public override string ToString()
        {
            var result =
                $"First name: {FirstName}, Last name: {LastName}, Gender: {Gender}, DateOfBirth: {DateOfBirth.ToString("dd/MM/yyyy")}, " +
                $"Phone number: {PhoneNumber}, Birth Place: {BirthPlace}, Age: {Age}, Is Graduated: {IsGraduated}";
            return result;
        }
    }
}
