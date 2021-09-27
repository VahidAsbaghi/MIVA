using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Infrastructure
{
    public class LoginExceptions:ApplicationException
    {
        private readonly ExceptionMessage _message;

        public LoginExceptions(ExceptionMessage message)
        {
            _message = message;
        }
    }
}
