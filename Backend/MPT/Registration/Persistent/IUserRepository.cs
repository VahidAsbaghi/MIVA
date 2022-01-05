using System.Threading.Tasks;

namespace Registration.Persistent
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
    }
}