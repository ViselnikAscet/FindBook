using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Interfaces.Repositories
{

    public interface IUserRepository: IBaseRepository<User>
    {   
        Task<User> GetForLogin(UserLoginDto login);

    }




}