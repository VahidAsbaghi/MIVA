using Login.Core.Model;

namespace Login.Application.Services
{
    //https://github.com/joydipkanjilal/jwt-aspnetcore/blob/master/jwt-aspnetcore/ITokenService.cs
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
