using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Globalization;
using TaskManager.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;

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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var task = _context.Chores.FirstOrDefault(x => x.ChoreID == id);
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                _context.Chores.Remove(task);
                _context.SaveChanges();
                return Ok();
            }
        }
        //Update method
        [HttpPost("{id}")]
        public IActionResult Update(int id, [FromBody] EditTaskRequest request)
        {
            var task = _context.Chores.FirstOrDefault(x => x.ChoreID == id);
            var updatedTask = new Chore();
            if (task == null)
            {
                return NotFound();
            }
            else
            {
                task.Name = request.Name;
                task.Description = request.Description;
                task.Deadline = DateTime.Parse(request.Deadline, _dateFormat, DateTimeStyles.AdjustToUniversal);
                task.TaskDone = request.TaskDone;
                //person here
                _context.Update(task);
                _context.SaveChanges();
                return Ok($"item with id: {id} updated");
            }
            
        }

        [HttpGet("search/{nameQuery}")]
        public IActionResult SearchTaskByName(string nameQuery) {
            
            var searchResult = from q in _context.Chores
                               where q.Name.ToLower().Contains(nameQuery.ToLower())
                               select q;

            return Ok(searchResult.ToList());
        }

        [HttpGet("today")]
        public IActionResult Get() { // return all the tasks which deadline is for today
            
            var ForToday = from tasks in _context.Chores
                           where tasks.Deadline == DateTime.Today.Date
                           select tasks;
            return Ok(ForToday);
        }

        //public async Task<IActionResult> Index(string searchName) {
        //    var task = from t in _context.Chores
        //               select t;
        //    if(!String.IsNullOrEmpty(searchName)) {
        //        task = task.Where(s => s.Name!.Contains(searchName));
        //    }

        //    return View(await task.ToListAsync());
        //}

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
