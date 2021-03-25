using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIWithAuthCore.Data;
using WebAPIWithAuthCore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIWithAuthCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuotesController : ControllerBase
    {
        private readonly DataService _dataService;

        public QuotesController(DataService dataService)
        {
            _dataService = dataService;
        }

        // GET: api/<QuotesController>
        [HttpGet]
        public IActionResult Get()
        {
            var x = this._dataService.GetQuotes();
            if(x != null)
            {
                return Ok(x);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/<QuotesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuotesController>
        [HttpPost]
        public IActionResult Post([FromBody] Quote value)
        {
            var result = this._dataService.AddQuotes(value);
            if (result)
            {
                return Created("",value);
            }
            else
            {
              return  BadRequest("Item Already Exist");
            }
        }

        // PUT api/<QuotesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote value)
        {
            var result = this._dataService.UpdateQuotes(id,value);
            if (result)
            {
                return Ok("Update Success");
            }
            else
            {
                return BadRequest("Cannot Update");
            }
        }

        // DELETE api/<QuotesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = this._dataService.DeleteQuotes(id);
            if (result)
            {
                return Ok("Quote deleted");
            }
            else
            {
                return BadRequest("Cannot Delete");
            }
        }
    }
}
