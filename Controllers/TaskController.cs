using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;
using System.Globalization;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ApplicationContext _context; //Reference to Data Base
        CultureInfo _dateFormat = new CultureInfo("en-US");
        public TaskController(ApplicationContext context) {
            _context = context;
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
                           where tasks.Deadline == DateTime.Now.Date
                           select tasks;
            return Ok(ForToday);
        }

        [HttpPost("newtask")]
        public IActionResult Add([FromBody] AddChoreRequest request)
        {
            var newChore = new Chore
            {
                ChoreID = request.ChoreID,
                Name = request.Name,
                Description = request.Description,
                CreatedTime = DateTime.Now,
                Deadline = DateTime.Parse(request.Deadline, _dateFormat, DateTimeStyles.AdjustToUniversal),
                Person  = _context.Persons.Find(request.PersonID)
            };
            _context.Add(newChore);
            _context.SaveChanges();
            return Ok("chore added");

        }
    }
}
