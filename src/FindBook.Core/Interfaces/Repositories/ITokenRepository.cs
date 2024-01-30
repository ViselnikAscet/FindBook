using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{

    public interface ITokenRepository: IBaseRepository<Token>
    {   
        Task<Token> CheckModuleToken(int moduleCode);
        
    }


}