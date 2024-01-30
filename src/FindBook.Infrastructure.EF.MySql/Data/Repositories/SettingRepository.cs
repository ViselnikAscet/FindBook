using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Setting;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {

        public SettingRepository(AracaParcaContext context, ILogger<SettingRepository> logger) : base(context, logger)
        {

        }
        public override async Task<IReadOnlyList<Setting>> GetListAsync(bool isActiveFilter = false, bool isActive = true, bool isTracking = false)
        {
            if (isTracking)
            {
                return await Table.Where(x => (isActiveFilter && x.IsActive == isActive) || (!isActiveFilter)).Include(x => x.Language).AsNoTracking().ToListAsync();

            }
            else
            {
                return await Table.Where(x => (isActiveFilter && x.IsActive == isActive) || (!isActiveFilter)).Include(x => x.Language).ToListAsync();

            }

        }

        public async Task<Setting> GetDefault()
        {
            return await Table.Where(x => x.IsActive && x.IsDefault)
            .Include(x => x.Language).FirstOrDefaultAsync();
        }

        public async Task<Setting> GetWithLanguage(int id)
        {
            return await Table.Where(x => x.Id == id).Include(x => x.Language).FirstOrDefaultAsync();

        }

        public async Task<Setting> CheckRequiredSetting(int id)
        {
            return await Table.Where(x=>x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Setting> GetSettingWithId(int id)
        {
            return await Table.Where(x=>x.IsActive && x.Id == id)

            .FirstOrDefaultAsync();
        }
    }


}

