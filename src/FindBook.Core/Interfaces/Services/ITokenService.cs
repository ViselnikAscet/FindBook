using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Brand;
using FindBook.Core.Models.Dto.Token;

namespace FindBook.Core.Interfaces.Services
{

    public interface ITokenService:IBaseService<TokenDto>
    {
        
        Task<Response<TokenDto>> CheckModuleToken(int moduleCode , int languageId);
        
    }


}