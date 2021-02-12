using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Service;
using Interfaces;
using Models;

namespace NixWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        ILogger<HomeController> _logger;
        IUserService service; 

        public HomeController(ILogger<HomeController> logger, IUserService service)
        {
            _logger = logger;
            this.service = service;
        }

        [HttpGet]
        public void Add(User user)
        {
            service.CreateUser(user);
        }
    }
}
