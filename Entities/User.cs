using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ExtraInfo { get; set; }
        
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<UserChores> UserChores { get; set; }
        
    }
}
