using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Interfaces;
using Microsoft.AspNetCore.Cors;
using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Helpers;
using System.IdentityModel.Tokens.Jwt;
using Models;
using ModelsUI;
using Helpers.Validators;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Models.UI;
using System.Linq;

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
        IValidator<User> userValidator;
        IValidator<CourseUI> courseValidator;
        public HomeController(ILogger<HomeController> logger, IValidator<User> userValidator, IValidator<CourseUI> courseValidator, IUserService userService, ICourseService courseService)
        {
            this.logger = logger;
            this.userService = userService;
            this.courseService = courseService;
            this.userValidator = userValidator;
            this.courseValidator = courseValidator;
        }
        string GenerateJWT(User user)   
        {
            var securityKey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            IEnumerable<Claim> claims = new List<Claim>
            {
             new Claim("Name",user.Name),
             new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name),
             new Claim("Id",user.Id.ToString())
            };
            var token = new JwtSecurityToken(
                claims: claims,
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                expires: DateTime.Now.AddMinutes(AuthOptions.LIFETIME), 
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [Route("adduser")]
        [HttpPost]
        public async Task<IActionResult> Registration(User user)
        {
            IActionResult response;
            bool isValid = userValidator.Validate(user);
            if (!isValid)
            {
                response = BadRequest();
                return response;
            }
            var ifExists = await userService.IfUserExists(user.Email, user.Password);
            if (ifExists)
            {
                response = StatusCode(409, "User with this data already exists");
                return response;
            }
            await userService.CreateUser(user);
            var tokenString = GenerateJWT(user);
            response = Ok(new
            {
                token = tokenString,
                userData = user
            });
            return response;
        }
        [Route("getuser")]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            IActionResult response;
            var loginData = await userService.GetUser(user);
            if (loginData != null)
            {
                var tokenString = GenerateJWT(loginData);
                response = Ok(new
                {
                    token = tokenString,
                    userData = loginData
                });
            }
            else
            {
                response = BadRequest();
            }
            return response;
        }
        [Authorize(Roles = "Default")]
        [Route("addcourse")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseUI course)
        {
            IActionResult response;
            bool isValid = courseValidator.Validate(course);
            if (!isValid)
            {
                response = BadRequest();
                return response;
            }
            await courseService.CreateCourse(course);
            response = Ok();
            return response;
        }
        [Authorize(Roles = "Default")]
        [Route("addcourseForUser")]
        [HttpPost]
        public async Task<IActionResult> AddCourseForUser([FromBody]int courseId)
        {
            IActionResult response;
            bool ifCourseExists = await courseService.IfCourseExists(courseId);
            if (!ifCourseExists)
            {
                response = BadRequest();
                return response;
            }
            int userId = int.Parse(HttpContext.User.FindFirst(c => c.Type == "Id").Value);
            await courseService.AddCourseForUser(courseId, userId);
            response = Ok();
            return response;
        }
        [Route("getmaterials")]
        [HttpPost]
        public async Task<IActionResult> GetMaterials([FromBody]int page)
        {
            var allMaterials = await courseService.GetMaterials(page);
            var result = allMaterials;
            return Ok(result);
        }
        [Route("getcourses")]
        [HttpPost]
        public async Task<IActionResult> GetCourses(SearchDetails details)
        {
            IActionResult response = Unauthorized();
            var courses = await courseService.SearchAllCourses(details.Name, details.Page);
            if (courses != null)
            {
                response = Ok(courses);
            }
            else
            {
                response = NotFound();
            }
            return response;
        }
        [Route("getcoursesForUser")]
        [HttpPost]
        public async Task<IActionResult> GetUserCourses([FromBody]int page)
        {
            IActionResult response;
            int userId = int.Parse(HttpContext.User.FindFirst(c => c.Type == "Id").Value);
            var courses = await courseService.GetAllUserCourses(userId, page);
            response = Ok(courses);
            return response;
        }
        [Route("updateMaterialsForUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateMaterialsForUser([FromBody]IEnumerable<int> materialsId)
        {
            IActionResult response;
            int userId = int.Parse(HttpContext.User.FindFirst(c => c.Type == "Id").Value);
            await courseService.AddCompletedMaterials(materialsId, userId);
            response = Ok();
            return response;

        }
        [Route("getSkills")]
        [HttpPost]
        public async Task<IActionResult> GetSkills([FromBody] int page)
        {
            IActionResult response;
            var skills = await courseService.GetSkills(page);
            response = Ok(skills);
            return response;
        }
    }
}
