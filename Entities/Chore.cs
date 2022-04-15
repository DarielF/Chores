using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class Chore
    {
        public int ChoreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime Deadline { get; set; }
        public Person Person { get; set; }

    }
}
