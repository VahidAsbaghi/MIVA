using System.Threading.Tasks;
using Login.Controlers;

namespace Login.Infrastructure.Helper
{
    public interface IAuthenticateService
    {
        Task<string> Authenticate(Credentials credentials);
    }
}