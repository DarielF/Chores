using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    public class UserChores
    {
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Chore")]
        public int ChoreId { get; set; }
        public Chore Chore { get; set; }
    }
}
