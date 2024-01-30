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

    public class OemRepository: BaseRepository<Oem>, IOemRepository
    {
        
        public OemRepository(AracaParcaContext context, ILogger<OemRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<bool> CheckOem(string searchText)
        {
           return (await Table.Where(x=>x.OemCode == searchText ).CountAsync()) >0;
        }
    }


}