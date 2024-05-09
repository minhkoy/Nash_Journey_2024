using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Models.Requests.Tasks
{
    public class CreateTaskRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool? IsCompleted { get; set; }
        public bool GetValidationResult()
        {
            if (string.IsNullOrWhiteSpace(Title) || !IsCompleted.HasValue) return false;
            return true;
        }
    }
}
