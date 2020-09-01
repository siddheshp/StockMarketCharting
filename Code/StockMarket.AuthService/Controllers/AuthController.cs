using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StckMarket.Models;
using StockMarket.AuthService.Repositories;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepository<User> repository;

        public AuthController(IRepository<User> repository)
        {
            this.repository = repository;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IActionResult Get(string username, string password)
        {
            //SSV
            if (!(string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password)))
            {
                try
                {
                    var result = repository.Login(username, password);
                    // success -> token
                    if (result.Item1)
                    {
                        return Ok(result.Item2); //token
                    }
                    // fail -> 
                    // invalid credentials
                    else
                    {
                        return BadRequest("Invalid credentials");
                    }
                }
                catch (Exception ex) // internal server error
                {
                    return StatusCode(500, "internal server error");
                }
            }
            return BadRequest("Please pass both username and password");
        }

        // GET api/<AuthController>/5
        [HttpGet("logout")]
        public IActionResult Get()
        {
            repository.Logout();
            return Ok("loged out");
        }

        // POST api/<AuthController>
        // register new user / signup
        [HttpPost]
        public IActionResult Post([FromForm] User user)
        {
            //SSV
            if (ModelState.IsValid)
            {
                //pass to repository
                var isSuccess = repository.Signup(user);
                if (isSuccess)
                {
                    return Ok("User registered successfully");
                }
                return StatusCode(500, "Internal server error");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            var currentUser = HttpContext.User;
            //TODO
            var email = currentUser.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub).Value;
            var result = repository.GetProfile(email);
            return Ok(result);
        }
    }
}
