using TaskManager.Models;

namespace TaskManager
{
    public class AddUserResponse
    {
        public bool IsSuccessful { get; set; }
        public Tokens? Token { get; set; }
    }
}
