using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class CampaignDetailRepository: BaseRepository<CampaignDetail>, ICampaignDetailRepository
    {
        
        public CampaignDetailRepository(FindBookContext context, ILogger<CampaignDetailRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<CampaignDetail>> GetCampaignDetail(int campaignId)
        {
            return await Table.Where(x=>x.CampaignId == campaignId).ToListAsync();
        }
    }

    internal interface ICampaignDetailRepository
    {
    }
}