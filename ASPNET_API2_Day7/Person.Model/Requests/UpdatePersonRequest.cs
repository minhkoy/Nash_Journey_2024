using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.Requests
{
    public class UpdatePersonRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string BirthPlace { get; set; }
        public UpdatePersonRequest() { }

        public bool GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(Id) ||
                string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)
                || string.IsNullOrWhiteSpace(BirthPlace)
                || !Gender.HasValue || !DateOfBirth.HasValue) return false;
            return true;
        }
    }
}
