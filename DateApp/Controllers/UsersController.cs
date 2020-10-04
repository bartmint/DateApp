using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DateApp.Domain.Abstract;
using System.Linq;
using DateApp.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using DateApp.UI.Models.DTO;
using System.Security.Claims;

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
        public ActionResult<IEnumerable<MemberVm>> GetUsers()
        {
            var usersToReturn = _userRepository.GetUsersAsync().ProjectTo<MemberVm>(_mapper.ConfigurationProvider);
            return Ok(usersToReturn);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; //powinno zwrocic username z tokenu
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);
            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("failed to update user");
        }

    }
}
