using CleanArchitecture.MVC.Models;
using System.Threading.Tasks;

namespace CleanArchitecture.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(RegisterVM registration);
        Task Logout();
    }
}
