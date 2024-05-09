using Person.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Model.Entities
{

    public class ThePerson
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string BirthPlace { get; set; }

        public string FullName { get => string.Concat(FirstName, " ", LastName); }
    }
}
