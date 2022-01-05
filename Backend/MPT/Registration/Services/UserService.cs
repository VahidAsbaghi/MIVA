using System.Threading.Tasks;
using Registration.Persistent;

namespace Registration.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }
    }
}
