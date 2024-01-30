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

    public class PermRepository : BaseRepository<Perm>, IPermRepository
    {

        public PermRepository(AracaParcaContext context, ILogger<PermRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<Perm>> GetMenuByPermGroupId(int permGroupId)
        {
            return await Table.Where(x => x.IsActive  && x.InMenu && ( x.PermGroupPerms.Where(z => z.PermGroupId == permGroupId).Count() > 0 || x.AllowEveryTime)).OrderBy(x=>x.MenuPriorty).AsNoTracking().ToListAsync();
        }
        public async Task<List<Perm>> GetNotAllowEveryTime()
        {
            return await Table.Where(x=>!x.AllowEveryTime && x.IsActive && (x.MenuType==Core.Models.Enum.MenuType.Definitions || x.MenuType==Core.Models.Enum.MenuType.Main)).AsNoTracking().ToListAsync();
        }

        public async Task<List<Perm>> GetPerms(int permGroupId)
        {
            return await Table.Where(x => x.IsActive && ((x.AllowEveryTime) || (!x.AllowEveryTime && x.PermGroupPerms.Where(z => z.PermGroupId == permGroupId).Count() > 0))).AsNoTracking().ToListAsync();
        }
    }


}