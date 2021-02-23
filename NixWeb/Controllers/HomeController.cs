using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Service;
using Interfaces;
using Models;
using Microsoft.AspNetCore.Cors;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Helpers;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace NixWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class HomeController : ControllerBase
    {
        ILogger<HomeController> logger;
        IUserService userService;
        ICourseService courseService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, ICourseService courseService)
        {
            this.logger = logger;
            this.userService = userService;
            this.courseService = courseService;
        }
        string GenerateJWT(User user)
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            IEnumerable<Claim> claims = new List<Claim>
            {
             new Claim("Name",user.Name),
             new Claim("Role",user.Role.Name)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10080), //1 week lifetime
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [Route("adduser")]
        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            IActionResult response = Unauthorized();
            await userService.CreateUser(user);
            var tokenString = GenerateJWT(user);
            response = Ok(new
            {
                token = tokenString,
                userData = JsonConvert.SerializeObject(user)
            });
            return response;
        }
        [Route("getuser")]
        [HttpGet]
        public async Task<IActionResult> Login(User user)
        {
            var loginData = await userService.GetUser(user);
            IActionResult response = Unauthorized();
            if (loginData != null)
            {
                var tokenString = GenerateJWT(loginData);
                response = Ok(new
                {
                    token = tokenString,
                    userData = loginData
                });
            }
            return response;
        }
        [Route("addcourse")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            await courseService.CreateCourse(course);
            return Ok();
        }
    }
}
