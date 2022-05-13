using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Entities;
using TaskManager;

namespace TaskManager.Services
{
    public class UserServices:IUserServices
    {
        private readonly IJWTManagerRepository _jwtRepository;
        private readonly ApplicationContext _context;
        public UserServices(ApplicationContext context, IJWTManagerRepository jwtRepository) {
            _context = context;
            _jwtRepository = jwtRepository;
        }

        public AddUserResponse Register(RegisterRequest request) {
            var userDB = _context.Users;
            if (userDB.Any()) {
                var userDb = userDB.FirstOrDefault(x => x.Email == request.Email || x.Username == request.Username);
                if (userDb == null)
                {
                    return new AddUserResponse
                    {
                        IsSuccessful = false,
                        Token = null
                    };
                }
            }

            var newUser = new User {
               Username = request.Username,
               Email = request.Email,
               Password = request.Password
            };

            var token = _jwtRepository.Authenticate(new LoginRequest { 
                        Username = request.Username,
                        Email = request.Email,
                        Password = request.Password
            });
            _context.Add(newUser);
            _context.SaveChanges();
            return new AddUserResponse
            {
                IsSuccessful = true,
                Token = token
            };
        }
    }
}
