using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.Model.DTOs;
using Person.Model.DTOs.Common;
using Person.Model.Requests;
using Person.Service.Interfaces;

namespace Person.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        // GET: api/<PersonsController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personService.GetAll());
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost("Query")]
        public IActionResult GetPagingPeople([FromBody] GetPagingPeopleRequest request)
        {
            var result = _personService.GetPagingPeople(request);
            return Ok(new BaseDTO<List<PersonDTO>>
            {
                Data = result,
                PageIndex = request.PageIndex,
                TotalCount = result.Count,
            });
        }

        // POST api/<PersonsController>
        [HttpPost]
        public IActionResult Create([FromBody] CreatePersonRequest person)
        {
            var newPerson = _personService.Create(person);
            return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, newPerson);
        }

        [HttpPost("Range")]
        public IActionResult CreateRange([FromBody] List<CreatePersonRequest> persons)
        {
            var newPersons = _personService.CreateRange(persons);
            return Created(value: newPersons, uri: null as string);
        }
        // PUT api/<PersonsController>/5
        [HttpPut]
        public IActionResult Edit([FromBody] UpdatePersonRequest person)
        {
            var updatedPerson = _personService.Update(person);
            if (updatedPerson is null)
            {
                return NotFound();
            }
            return Ok(updatedPerson);
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            var deleteResult = _personService.Delete(id);
            if (!deleteResult)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("Range")]
        public IActionResult DeleteRange([FromQuery] List<string> ids)
        {
            var deleteResult = _personService.DeleteRange(ids);
            if (!deleteResult)
            {
                return BadRequest("There is failure when deleting the entries. The data is still kept unmodified.");
            }
            return NoContent();
        }
    }
}
