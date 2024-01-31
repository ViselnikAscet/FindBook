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

    public class ErrorRepository: BaseRepository<Error>, IErrorRepository
    {
        
        public ErrorRepository(FindBookContext context, ILogger<ErrorRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<Error> GetByCode(string code, int languageId)
        {
            return await Table.Where(x=>x.Code==code && x.LanguageId == languageId).FirstOrDefaultAsync();
        }
    }


}