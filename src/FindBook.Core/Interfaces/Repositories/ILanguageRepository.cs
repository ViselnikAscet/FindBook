using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface ILanguageRepository:IBaseRepository<Language>
    {
        Task<Language> GetDefault();

        Task<List<Language>>  GetAllLanguage();
    }
}