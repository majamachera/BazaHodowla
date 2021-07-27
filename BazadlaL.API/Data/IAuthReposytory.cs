using System.Threading.Tasks;
using BazadlaL.API.Models;

namespace BazadlaL.API.Data
{
    public interface IAuthReposytory
    {
        Task<User> Login(string username, string password);
        Task<User> Register(User user, string password, string emaile);
        Task<bool> UserExist(string username);

    }
}