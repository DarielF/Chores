using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;

namespace TaskManager
{
    public class EditTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool TaskDone { get; set; }
        public string Deadline { get; set; }
        public User Person { get; set; }
    }
}
