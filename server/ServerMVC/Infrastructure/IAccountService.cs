using ServerMVC.Models;
using System.Security.Claims;

namespace ServerMVC.Infrastructure
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
