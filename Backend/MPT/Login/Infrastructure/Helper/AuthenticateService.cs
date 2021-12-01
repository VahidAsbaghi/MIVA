using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Controlers;
using Login.Core.Model;
using Login.Core.Services;
using Login.Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Login.Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthenticateService(IUserRepository userRepository,ITokenService tokenService,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _configuration = configuration;
        }
        public async Task<string> Authenticate(Credentials credentials)
        {
            var user=await _userRepository.GetByUsername(credentials.Username);
            if (user==null)
            {
                return null;//Todo Generate appropriate exception
            }

            var passwordHasher = new PasswordHasher<User>();
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, credentials.Password);
            if (verificationResult==PasswordVerificationResult.Success)
            {
                var token=_tokenService.BuildToken(_configuration["Jwt:Key"], _configuration["Jwt:Issuer"], user);
                return token;
            }
            else
            {
                return null;//todo throw appropriate exception
            }
        }
    }
}
