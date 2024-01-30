using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class CurrencyRepository : BaseRepository<Currency> , ICurrencyRepository
    {

        public CurrencyRepository(AracaParcaContext context, ILogger<CurrencyRepository> logger) : base(context, logger)
        {

        }

        public async Task<Currency> GetCurrencyWithId(int currencyId)
        {
           return await Table.Where(x=>x.Id == currencyId).FirstOrDefaultAsync();
        }
    }


}