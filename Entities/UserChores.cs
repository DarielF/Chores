using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    
    public class UserChores
    {


        public int UserId { get; set; }
        public User User { get; set; }
       
        public int ChoreId { get; set; }
        public Chore Chore { get; set; }
    }
}
