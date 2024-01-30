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

    public class CampaignDetailRepository: BaseRepository<CampaignDetail>, ICampaignDetailRepository
    {
        
        public CampaignDetailRepository(AracaParcaContext context, ILogger<CampaignDetailRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<CampaignDetail>> GetCampaignDetail(int campaignId)
        {
            return await Table.Where(x=>x.CampaignId == campaignId).ToListAsync();
        }
    }


}