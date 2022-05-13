using TaskManager.Models;

namespace TaskManager
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(LoginRequest user);
    }
}
