using JWTWebAuthentication;
using TaskManager.Models;

namespace JWTWebAuthentication.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(LoginRequest user);
    }
}
