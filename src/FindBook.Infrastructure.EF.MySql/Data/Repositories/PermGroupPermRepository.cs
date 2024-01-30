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

    public class PermGroupPermRepository : BaseRepository<PermGroupPerm>, IPermGroupPermRepository
    {

        public PermGroupPermRepository(AracaParcaContext context, ILogger<PermGroupPermRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<PermGroupPerm>> GetListByPermGroupId(int permGroupId)
        {
            return await Table.Where(x=>x.PermGroupId == permGroupId).AsNoTracking().ToListAsync();
        }
    }


}