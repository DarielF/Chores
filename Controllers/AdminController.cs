using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.Services;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IJWTManagerRepository _jWTManager;
        private readonly IUserServices _userServices;
        public AdminController(ApplicationContext context, IJWTManagerRepository jWTManager, IUserServices userServices)
        {
            this._jWTManager = jWTManager;
            _context = context;
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Users);
        }

        [HttpPost("addPerson")]
        public IActionResult Add([FromBody] AddUserRequest request)
        {
            var newPerson = new User
            {
                UserID = request.ID,
                Name = request.Name,
                LastName = request.LastName,
                //ExtraInfo = request.ExtraInfo
            };
            _context.Add(newPerson);
            _context.SaveChanges();
            return Ok("Person added");

        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(LoginRequest usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterRequest request) {
            
            var response = _userServices.Register(request);
            return Ok(response);
        }
    }
}
