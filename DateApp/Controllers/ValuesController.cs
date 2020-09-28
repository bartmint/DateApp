using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateApp.Domain.Models;
using DateApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //http:localhost:5000/api/values to oznacza
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _ctx;

        public ValuesController(AppDbContext appDbContext)
        {
            _ctx = appDbContext;
        }
        // GET api/values
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return Ok(await _ctx.Values.ToListAsync());
        //}
        // GET api/values/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _ctx.Values.Where(p => p.Id == id).FirstOrDefaultAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ctx.Users.ToListAsync());
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
