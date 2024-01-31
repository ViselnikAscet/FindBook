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

    public class LanguageBasedInfoRepository : BaseRepository<LanguageBasedInfo>, ILanguageBasedInfoRepository
    {

        public LanguageBasedInfoRepository(FindBookContext context, ILogger<LanguageBasedInfoRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<LanguageBasedInfo>> GetCampaignLanguageBasedInfos(int campaignId)
        {
            return await Table.Where(x=>x.CampaignId == campaignId && x.IsActive).ToListAsync();
        }

        public async Task<List<LanguageBasedInfo>> GetMenuItemAllLangBasedInfos(int menutItemId)
        {
            return await Table.Where(x=>x.MenuItemId == menutItemId && x.IsActive).ToListAsync();
        }

        public async Task<LanguageBasedInfo> GetProductInfo(int productId)
        {
            return await Table.Where(x => x.IsActive && x.ProductId == productId).FirstOrDefaultAsync();

        }

        public async Task<List<LanguageBasedInfo>> GetVehicleAllLangBasedInfos(int vehicleId)
        {
            return await Table.Where(x=>x.IsActive && x.VehicleId == vehicleId).ToListAsync();
        }

        public async Task<LanguageBasedInfo> GetVehicleInfo(int vehicleId, int languageId)
        {
            return await Table.Where(x=>x.LanguageId == languageId && x.VehicleId == vehicleId && x.IsActive).FirstOrDefaultAsync();
        }
    }


}