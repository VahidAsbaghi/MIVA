using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Controlers;
using Login.Core.Services;

namespace Login.Application.Services
{
    public class AuthenticateService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public string Authenticate(Credentials credentials)
        {
            return ""; //_userRepository.GetById()
        }
    }
}
