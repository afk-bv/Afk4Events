using System;
using Afk4Events.Data.Entities.Users;
using Afk4Events.Models;
using Afk4Events.Models.Users;
using Afk4Events.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace Afk4Events.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.Get(id);
            var responseModel = new UserDto()
            {
                Name = user.Name,
                ProfilePictureUrl = user.ProfilePictureUrl,
                Email = user.Email
            };
            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]UserDto userModel)
        {
            var user = new User()
            {
                Name = userModel.Name,
                Email = userModel.Email,
                ProfilePictureUrl = userModel.ProfilePictureUrl
            };
            _userService.Create(user);
            return Ok();
        }
    }
}
