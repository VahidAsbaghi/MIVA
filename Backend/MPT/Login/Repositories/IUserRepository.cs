using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login.Model;

namespace Login.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);

    }
}
