using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Infrastructure
{
    public class ExceptionMessage
    {
        public static readonly string AddUserException =
            $"ExceptionCode={ExceptionCode.AddUserDbFailed}, Add user in db failed";
    }
}
