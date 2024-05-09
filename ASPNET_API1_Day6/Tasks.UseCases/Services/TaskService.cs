using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.Models.DTOs;
using Tasks.Models.Repositories;
using Tasks.Models.Requests.Tasks;

namespace Tasks.UseCases.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public TaskDTO Create(CreateTaskRequest task)
        {
            if (task is null || !task.GetValidationResult())
            {
                throw new ValidationException("Validation fails. Title and status are required.");
            }
            return _taskRepository.Add(task);
        }
        public List<TaskDTO> CreateRange(List<CreateTaskRequest> tasks)
        {
            return _taskRepository.AddRange(tasks);
        }
        public TaskDTO? GetById(string id)
        {
            return _taskRepository.GetById(id);
        }
        public IEnumerable<TaskDTO> GetAll()
        {
            return _taskRepository.GetAll();
        }
        public TaskDTO? Update(UpdateTaskRequest task)
        {
            if (task is null || !task.GetValidationResult())
            {
                throw new ValidationException("Validation fails. All fields are required.");
            }
            return _taskRepository.Update(task);
        }
        public bool Delete(string id)
        {
            return _taskRepository.Delete(id);
        }

        public bool DeleteRange(List<string> ids)
        {
            return _taskRepository.DeleteRange(ids);
        }
    }
}
