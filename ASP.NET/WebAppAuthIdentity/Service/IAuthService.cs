using WebAppAuthIdentity.Models;

namespace WebAppAuthIdentity.Service
{
    public interface IAuthService
    {
        Task<User> WalidateUse(string username, string password);
    }
}
