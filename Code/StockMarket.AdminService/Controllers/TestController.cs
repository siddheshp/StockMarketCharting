using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StockMarket.AdminService.Models;
using StockMarket.AdminService.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IUploadRepository repository;

        public TestController(IUploadRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        //[Consumes("application/x-www-form-urlencoded")]
        public void Post([FromForm] string value)
        {
            if (ModelState.IsValid)
            {
                //repository.
            }
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("/api/test/upload")]
        public IActionResult Upload([FromForm]IFormFile file1)
        {
            if (file1 == null)
            {
                return BadRequest("must upload a file");
            }
            //check file extension

            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "UploadFiles");
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        repository.UploadExcel(fullPath);
                    }
                    return Ok("Upload successful");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



        private IActionResult GenerateJwtToken(string email,
            IdentityUser user)
        {
            //var claims = new List<Claim>
            //{
            //    new Claim(JwtRegisteredClaimNames.Sub, email),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    new Claim(ClaimTypes.NameIdentifier, user.Id)
            //};

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            //    configuration["JwtKey"]));
            //var creds = new SigningCredentials(key,
            //    SecurityAlgorithms.HmacSha256);
            //// recommednded is 5 mins
            //var expires = DateTime.Now.AddDays(
            //    Convert.ToDouble(configuration["JwtExpireDays"]));

            //var token = new JwtSecurityToken(
            //    configuration["JwtIssuer"],
            //    configuration["JwtIssuer"],
            //    claims,
            //    expires: expires,
            //    signingCredentials: creds
            //);

            //return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            return Ok();
        }
    }
}
