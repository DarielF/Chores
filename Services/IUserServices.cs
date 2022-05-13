using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    public interface IUserServices
    {
        public AddUserResponse Register(RegisterRequest request);
    }
}
