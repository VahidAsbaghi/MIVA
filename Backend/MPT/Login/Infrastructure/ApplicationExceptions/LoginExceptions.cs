using System;

namespace Login.Infrastructure.ApplicationExceptions
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
