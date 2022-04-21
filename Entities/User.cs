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

    }
}
