using System.Threading.Tasks;
using Login.Core.Model;

namespace Login.Core.Services
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<User> GetByCredentials(string passwordHash);
    }
}
