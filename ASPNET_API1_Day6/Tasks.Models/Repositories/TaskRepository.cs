using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models.DTOs;
using Tasks.Models.Requests.Tasks;

namespace Tasks.Models.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private List<TheTask> _taskList = new List<TheTask>();
        public TaskRepository()
        {
            for (int i = 1; i <= 23; i++)
            {
                _taskList.Add(new TheTask
                {
                    IsCompleted = i % 2 == 0,
                    Title = $"Task number {i}",
                });
            }
        }
        public TaskDTO Add(CreateTaskRequest taskRequest)
        {
            TheTask newTask = new TheTask
            {
                Title = taskRequest.Title,
                IsCompleted = taskRequest.IsCompleted
            };
            _taskList.Add(newTask);
            return new TaskDTO
            {
                Id = newTask.Id,
                Title = newTask.Title,
                IsCompleted = newTask.IsCompleted
            };
        }

        public List<TaskDTO> AddRange(List<CreateTaskRequest> tasks)
        {
            tasks.ForEach(task => _taskList.Add(new TheTask
            {
                Title = task.Title,
                IsCompleted = task.IsCompleted
            }));
            return _taskList.Select(t => new TaskDTO
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            }).ToList();
        }

        public bool Delete(string id)
        {
            var taskToDelete = _taskList.FirstOrDefault(t => string.Equals(t.Id, id));
            if (taskToDelete is null)
            {
                return false;
            }
            _taskList.Remove(taskToDelete);
            return true;
        }

        public TaskDTO? GetById(string id)
        {
            var task = _taskList.FirstOrDefault(t => string.Equals(t.Id, id));
            if (task is null)
            {
                return null;
            } 
            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
        }

        public IEnumerable<TaskDTO> GetAll()
        {
            return _taskList.Select(t => new TaskDTO
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            });
        }

        public TaskDTO? Update(UpdateTaskRequest task)
        {
            var taskToUpdate = _taskList.FirstOrDefault(t => string.Equals(t.Id, task.Id));
            if (taskToUpdate is null)
            {
                return null;
            }
            taskToUpdate.Title = task.Title;
            taskToUpdate.IsCompleted = task.IsCompleted;
            return new TaskDTO
            {
                Id = taskToUpdate.Id,
                Title = taskToUpdate.Title,
                IsCompleted = taskToUpdate.IsCompleted
            };
        }

        public bool DeleteRange(List<string> ids)
        {
            List<TheTask> tasksToDelete = _taskList.Where(t => ids.Contains(t.Id)).ToList();
            if (tasksToDelete.Count != ids.Count)
            {
                return false;
            }
            List<TheTask> originalList = new();
            _taskList.CopyTo(originalList.ToArray());
            _taskList = _taskList.Except(tasksToDelete).ToList();
            if (_taskList.Count == originalList.Count - tasksToDelete.Count)
            {
                return true;
            }
            _taskList = originalList;
            return false;
        }
    }
}
