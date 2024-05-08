using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Models.DTOs
{
    public class TaskDTO
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public TaskDTO() { }
        public TaskDTO(string title, bool isCompleted)
        {
            Title = title;
            IsCompleted = isCompleted;
        }
    }
}
