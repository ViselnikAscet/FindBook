using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{

    public interface IErrorRepository: IBaseRepository<Error>
    {   
        Task<Error> GetByCode(string code, int languageId);
    }


}