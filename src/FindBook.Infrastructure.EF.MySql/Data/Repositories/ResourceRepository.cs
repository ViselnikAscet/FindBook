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

    public class ResourceRepository : BaseRepository<Resource>, IResourceRepository
    {

        public ResourceRepository(AracaParcaContext context, ILogger<ResourceRepository> logger) : base(context, logger)
        {

        }

        public async Task<string> GetByKey(string key, int langaugeId)
        {
            return await Table.Where(x => x.Key == key && x.LanguageId == langaugeId).Select(x => x.Value).FirstOrDefaultAsync();
        }

    }


}