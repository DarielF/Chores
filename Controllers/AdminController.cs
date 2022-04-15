﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Entities;


namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public AdminController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Persons);
        }

        [HttpPost("addPerson")]
        public IActionResult Add([FromBody] AddPersonRequest request)
        {

            var newPerson = new Person
            {
                PersonID = request.ID,
                Name = request.Name,
                LastName = request.LastName,
                ExtraInfo = request.ExtraInfo
            };
            _context.Add(newPerson);
            _context.SaveChanges();
            return Ok("Person added");

        }
        //private int IdGenerator() { 
        
        //}
    }
}
