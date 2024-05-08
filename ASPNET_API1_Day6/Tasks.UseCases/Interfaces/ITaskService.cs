using System.Collections.Generic;
using Tasks.Models.DTOs;
using Tasks.Models.Requests.Tasks;

namespace Tasks.UseCases.Services
{
    public interface ITaskService
    {
        TaskDTO Create(CreateTaskRequest task);
        List<TaskDTO> CreateRange(List<CreateTaskRequest> tasks);
        TaskDTO? GetById(string id);
        IEnumerable<TaskDTO> GetAll();
        TaskDTO? Update(UpdateTaskRequest task);
        bool Delete(string id);
        bool DeleteRange(List<string> ids);
    }
}
