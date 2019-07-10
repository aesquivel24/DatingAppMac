using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
            
        }
        // GET api/values
        [HttpGet]
        //adding async makes it an async method, Task<ActionToBeCompleted> where Task represents an async operation that can return a value
        public async Task<IActionResult> GetValues()
        {
            //stores what retrieved from database in values, _context is the database, gets what in Values.cs and makes them into a list with ToList();
            // await keyword makes the method know were wating fot this responce from the database
            var values = await _context.Values.ToListAsync();
            //Returns a 200 response with the all the information in values
            return Ok(values);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            //_context is the database, then .Values is the values were searching for, .FirstOrDefault will find the id that matches in the Table, x represents
            //the value were going to return, => x.Id this attaches x to the ID value in the database and == id makes sure it's equal to the id in the url 
            //so it's like when the Id in the database is == to the id being passed through, then set that to x and x is stored in value variable.
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
