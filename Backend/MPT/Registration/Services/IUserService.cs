using System.Threading.Tasks;
using Registration.Models;
using Registration.Persistent;

namespace Registration.Services
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
    }
}
