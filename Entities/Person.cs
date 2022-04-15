using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ExtraInfo { get; set; }

        public string GetFullName() {
            return Name + " " + LastName;
        }

        
    }
}
