﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager
{
    public class AddPersonRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ExtraInfo { get; set; }
    }
}
