using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students2Controller : ControllerBase
    {
        private IRepository<Student> repository;
        public Students2Controller(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        // GET: api/<Students2Controller>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return repository.Get();
        }

        [HttpGet("/api/students2/searchbydate")]
        public IEnumerable<Student> Get(DateTime from, DateTime to)
        {
            return repository.Search(from, to);
        }

        // GET api/<Students2Controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Students2Controller>
        [HttpPost]
        public IActionResult Post([FromForm] Student student)
        {
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(student);
                if (isAdded)
                {
                    return Created("student", student);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<Students2Controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Student student)
        {
            if (ModelState.IsValid)
            {
                if (id == student.Id)
                {
                    //is student found?
                    var existing = repository.Get(student.Id);
                    if (existing == null)
                    {
                        return NotFound();
                    }
                    
                    var isUpdated = repository.Update(student);
                    if (isUpdated)
                    {
                        return Ok(student);
                    }
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<Students2Controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = repository.Get(id);
            if (student == null)
            {
                return NotFound();
            }
            var isDeleted = repository.Delete(student);
            if (isDeleted)
            {
                return Ok("Student deleted successfully");
            }
            return StatusCode(500, "Internal server error");
        }
    }
}
