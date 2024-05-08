using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models.DTOs;
using Tasks.Models.Requests.Tasks;

namespace Tasks.Models.Repositories
{
    public interface ITaskRepository
    {
        TaskDTO Add(CreateTaskRequest task);
        List<TaskDTO> AddRange(List<CreateTaskRequest> tasks);
        TaskDTO? GetById(string id);
        IEnumerable<TaskDTO> GetAll();
        TaskDTO? Update(UpdateTaskRequest task);
        bool Delete(string id);
        bool DeleteRange(List<string> ids);
    }
}
