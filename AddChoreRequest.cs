using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager
{
    public class AddChoreRequest
    {
        public int ChoreID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Deadline { get; set; }
        public int PersonID { get; set; }

        //maybe create a function to get a person by his ID
    }
}
