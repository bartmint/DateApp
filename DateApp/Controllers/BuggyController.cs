using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DateApp.Domain.Models;
using DateApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DateApp.UI.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _ctx;

        public BuggyController(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _ctx.Users.Find(-1);
            if (thing == null) return NotFound();

            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            
            //    var thing = _ctx.Users.Find(-1);

            //try
            //{
            //    var thingToReturn = thing.ToString(); //generuje null reference exception
            //    return thingToReturn;
            //}
            //catch(Exception ex)
            //{
            //    return ex.Message;
            //}
            return StatusCode(500);
            
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {

            return BadRequest();
        }

    }
}
