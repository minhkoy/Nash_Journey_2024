using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.Requests
{
    public class CreatePersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string BirthPlace { get; set; }
        public CreatePersonRequest() { }

        public bool GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
                || string.IsNullOrWhiteSpace(BirthPlace)
                || !Gender.HasValue || !DateOfBirth.HasValue) return false;
            return true;
        }
    }

    public enum Gender
    {
        Male = 0,
        Female = 1,
        Others = 2,
        NotToMention = 3,
    }
}
