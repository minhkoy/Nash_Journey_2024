using Microsoft.AspNetCore.Mvc;
using Tasks.Models.DTOs;
using Tasks.Models.Repositories;
using Tasks.Models.Requests.Tasks;
using Tasks.UseCases.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        // GET: api/<TasksController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetAll());
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]string id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskRequest task)
        {
            var newTask = _taskService.Create(task);
            return CreatedAtAction(nameof(Get), new { id = newTask.Id }, newTask);
        }

        [HttpPost("Range")]
        public IActionResult CreateRange([FromBody] List<CreateTaskRequest> tasks)
        {
            var newTasks = _taskService.CreateRange(tasks);
            return Created(value: newTasks, uri: null as string);
        }
        // PUT api/<TasksController>/5
        [HttpPut]
        public IActionResult Edit([FromBody] UpdateTaskRequest task)
        {
            var updatedTask = _taskService.Update(task);
            if (updatedTask is null)
            {
                return NotFound();
            }
            return Ok(updatedTask);
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]string id)
        {
            var deleteResult = _taskService.Delete(id);
            if (!deleteResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("Range")]
        public IActionResult DeleteRange([FromQuery]List<string> ids)
        {
            var deleteResult = _taskService.DeleteRange(ids);
            if (!deleteResult)
            {
                return BadRequest("There is failure when deleting the entries. The data is still kept unmodified.");
            }
            return NoContent();
        }
    }
}
