using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Interfaces.Services
{

    public interface IUserService:IBaseService<UserDto>
    {
        Task<Response<UserDto>> GetUserLogin(UserLoginDto login, int languageId);     

        
    }




}