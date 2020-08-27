using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> studentList = new List<Student>()
        {
            new Student{Id=1, Name="Param",
                DateOfBirth = new DateTime(1996,1,1), Gender=Gender.Male},
            new Student{Id=2, Name="Shona",
                DateOfBirth = new DateTime(1996,1,1), Gender=Gender.Female}
        };

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return studentList;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = studentList.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post([FromForm] Student student)
        {
            //server side validation
            if (ModelState.IsValid)
            {
                // add student
                studentList.Add(student);
                // if failed, return InternalServerError
                // else created status
                return Created("student", student);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Student student)
        {
            if (ModelState.IsValid)
            {
                // mim
                if (id == student.Id)
                {
                    var existing = studentList.Find(s => s.Id == id);
                    if (existing == null)
                    {
                        return NotFound();
                    }
                    //update
                    return Ok(student);
                }
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //find student with id
            //delete
                // return ok
                // failed, return internal server error
        }
    }
}
