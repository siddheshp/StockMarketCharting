using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StckMarket.Models;
using StockMarket.AdminService.Repositories;
using StockMarket.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockMarket.AdminService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPricesController : ControllerBase
    {
        private IRepository<StockPriceDto> repository;

        public StockPricesController(IRepository<StockPriceDto> repository)
        {
            this.repository = repository;
        }
        // GET: api/<StockPricesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StockPricesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockPricesController>
        [HttpPost]
        public void Post([FromForm] StockPriceDto stockPriceDto)
        {
            //SSV
            if (ModelState.IsValid)
            {
                var isAdded = repository.Add(stockPriceDto);
            }
        }

        // PUT api/<StockPricesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockPricesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
