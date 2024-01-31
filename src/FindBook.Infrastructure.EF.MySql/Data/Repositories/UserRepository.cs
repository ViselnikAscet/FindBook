using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Models.Dto.User;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(FindBookContext context, ILogger<UserRepository> logger) : base(context, logger)
        {

        }

        public async Task<User> GetForLogin(UserLoginDto login)
        {
            return await Table.Where(x => x.Username == login.Username && x.Password == login.Password && x.IsActive).FirstOrDefaultAsync();
        }
    }


}