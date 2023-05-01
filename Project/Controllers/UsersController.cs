using Core.Services;
using DataLayer.Dtos;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private UserService userService { get; set; }

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterDto payload)
        {
            userService.Register(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto payload)
        {
            var jwtToken = userService.Validate(payload);
            if(jwtToken == null)
            {
                return Unauthorized();

            }
            return Ok(new { token = jwtToken });
        }


        [HttpGet("administrator-only")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<string> HelloStudents()
        {
            return Ok("Hello students!");
        }

        [HttpGet("user-only")]
        [Authorize(Roles = "User")]
        public ActionResult<string> HelloTeachers()
        {
            return Ok("Hello teachers!");
        }

        

      

    }
}
