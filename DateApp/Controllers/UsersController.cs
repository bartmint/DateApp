using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DateApp.Domain.Abstract;
using DateApp.Domain.Models;
using DateApp.Infrastructure;
using DateApp.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //http:localhost:5000/api/values to oznacza
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
 
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetUsers(int id)
        //{
        //    return Ok(await _userRepository.GetUserByIdAsync(id));
        //}
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberVm>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var userToReturn = _mapper.Map<MemberVm>(user);

            return Ok(userToReturn);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberVm>>> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();

            var usersToReturn = _mapper.Map<IEnumerable<MemberVm>>(users);
            return Ok(usersToReturn);
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
