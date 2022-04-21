using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Globalization;
using TaskManager.Entities;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationContext _context; //Reference to Data Base
        private readonly IConfiguration _configuration;
        private readonly CultureInfo _dateFormat;
               
        public TaskController(ApplicationContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
            _dateFormat = new CultureInfo(_configuration.GetValue<string>("DateFormat"));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var chores = _context.Chores;
            return Ok(chores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var task = _context.Chores.Find(id);
            if (task == null) {
                return NotFound("The task with the id " + id.ToString() + " doesn't exist");
            }
            return Ok(task);
        }

        

        [HttpGet("today")]
        public IActionResult Get() { // return all the tasks which deadline is for today
            
            var ForToday = from tasks in _context.Chores
                           where tasks.Deadline == DateTime.Today.Date
                           select tasks;
            return Ok(ForToday);
        }

        [HttpPost("addtask")]
        public IActionResult Add([FromBody] AddChoreRequest request)
        {
            var newChore = new Chore
            {
                ChoreID = request.ChoreID,
                Name = request.Name,
                Description = request.Description,
                CreatedTime = DateTime.Now,
                TaskDone = request.TaskDone,
                Deadline = DateTime.Parse(request.Deadline, _dateFormat, DateTimeStyles.AdjustToUniversal),
                //Person  = _context.Users.Find(request.UserID)
            };
            _context.Add(newChore);
            _context.SaveChanges();
            return Ok("chore added");

        }
    }
}
