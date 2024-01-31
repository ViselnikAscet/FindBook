using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class LanguageRepository: BaseRepository<Language>, ILanguageRepository
    {
        
        public LanguageRepository(FindBookContext context, ILogger<LanguageRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<Language>> GetAllLanguage()
        {
            return await Table.Where(x=>x.IsActive).ToListAsync();
        }

        public async Task<Language> GetDefault()
        {
            return await Table.Where(x=>x.IsActive && x.IsDefault).FirstOrDefaultAsync();
        }
    }


}