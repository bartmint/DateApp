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
using Microsoft.AspNetCore.Http;
using DateApp.UI.Extensions;
using DateApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using DateApp.UI.Helpers;
using System;
using DateApp.UI.Controllers;

namespace DatingApp.API.Controllers
{
    //http:localhost:5000/api/values to oznacza
    
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
       

        public UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _photoService = photoService;
            
        }
        [HttpGet("{username}", Name ="GetUser")]
        public async Task<ActionResult<MemberVm>> GetUser(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);

            var userToReturn = _mapper.Map<MemberVm>(user);
            
            return Ok(userToReturn);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberVm>>> GetUsers([FromQuery]UserParams userParams) //query jest pobierane z urla, ktory wpisujemy w postman
        {
            var user = await _userRepository.GetUserByIdAsync(User.GetUserId());

            if(user!=null)
                userParams.CurrentUsername = user.UserName;
            
            
            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = user.Gender == "male" ? "female" : "male";
            }

            var users =
                _userRepository.
                GetUsersAsync();
            
            users = users.Where(u => u.UserName != userParams.CurrentUsername);
            users = users.Where(u => u.Gender == userParams.Gender);

            var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
            var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

            users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
            users = userParams.OrderBy switch
            {
                "created" => users.OrderByDescending(u => u.Created),
                _ => users.OrderByDescending(u => u.LastActive)
            };

            var usersToReturn=users.ProjectTo<MemberVm>(_mapper.ConfigurationProvider)
            .AsNoTracking(); 


            var items =await PagedList<MemberVm>.CreateAsync(usersToReturn, userParams.PageNumber, userParams.PageSize);

            Response.AddPaginationHeader(items.CurrentPage, items.PageSize, items.TotalCount, items.TotalPages);

            return Ok(items);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.GetUsername(); //powinno zwrocic username z tokenu
            var user = await _userRepository.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto, user);

            _userRepository.Update(user);
            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("failed to update user");
        }
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoVm>> AddPhoto(IFormFile file)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null)
                return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            if (user.Photos.Count == 0)
            {
                photo.IsMain = true;
            }
            user.Photos.Add(photo);
            if (await _userRepository.SaveAllAsync())
            {
                return CreatedAtRoute("GetUser", new { username = user.UserName } ,_mapper.Map<PhotoVm>(photo));
            }
            return BadRequest("Problem adding photo");

        }
        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            //nie przechodzimy do bazy, bo usera zawieramy bezposrednio w pamieci
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);
            if (photo == null) return BadRequest("This photo doesnt exist");
            if (photo.IsMain) return BadRequest("This is already your main photo");

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain); //pobieramy zdjecie, ktore ma wartosc boolean true na isMain
            if (currentMain != null) currentMain.IsMain = false; //jesli istnieje takie zdjecie to zmienaimy wartosc na false
            photo.IsMain = true; // i przyslanemu id zdjecia ustawiamy true na isMain

            if (await _userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to set main photo");
        }
        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo=user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null) return NotFound();
            if (photo.IsMain) return BadRequest("You cannot delete main photo");
            if (photo.PublicId != null)
            {
               var result = await _photoService.DeletePhotoAsync(photo.PublicId);
               if (result.Error != null) return BadRequest(result.Error.Message);
            }
            user.Photos.Remove(photo);

            if (await _userRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete photo");

        }

    }
}
