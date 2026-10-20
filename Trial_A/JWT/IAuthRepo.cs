using Trial_A.DTOs.Auth;
using Trial_A.Models;

namespace Trial_A.JWT
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(User user);
    }
}
