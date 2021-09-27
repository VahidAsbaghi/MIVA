using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Login.Model;

namespace Login.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString= @"Data Source=.; Initial Catalog=UserDb;
                                                    Integrated Security=True";
        public async Task<User> GetById(string id)
        {
            string selectedUser = @"select TOP 1 * from UserTable
                                    where UserTable.Id = @UserId";
            await using var conn = new SqlConnection(_connectionString);
            var user = await
                conn.QuerySingleAsync<User>(
                    selectedUser,
                    new { UserId = id });
            return user;
        }

        public async Task<User> AddUser(User user)
        {
         const string addUserSql =
            @"insert into UserTable
                (Id, UserName, NormalizedUserName, Email, EmailConfirmed,PasswordHash,
                PhoneNumber, PhoneNumberConfirmed, LockoutEnd, LockoutEnabled, AccessFailedCount)
                values
                (@Id, @UserName, @NormalizedUserName, @Email, @EmailConfirmed, @PasswordHash,
                    @PhoneNumber, @PhoneNumberConfirmed, @LockoutEnd, @LockoutEnabled, @AccessFailedCount)";

         await using var conn = new SqlConnection(_connectionString);
         var count = await
             conn.ExecuteAsync(
                 addUserSql,
                 user).ConfigureAwait(false);
         return user;
        }


    }
}
