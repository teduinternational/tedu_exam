using AdminApp.Models;
using IdentityModel.Client;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }
}
