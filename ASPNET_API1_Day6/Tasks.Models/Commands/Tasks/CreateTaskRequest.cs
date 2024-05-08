using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Models.Requests.Tasks
{
    public class CreateTaskRequest
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
