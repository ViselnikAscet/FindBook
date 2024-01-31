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

    public class CampaignRepository: BaseRepository<Campaign>, ICampaignRepository
    {
        
        public CampaignRepository(FindBookContext context, ILogger<CampaignRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<Campaign>> GetAllCampaigns(int languageId)
        {
            return  await Table.Include(x => x.LanguageBasedInfos.Where(c => c.IsActive && c.LanguageId == languageId)).ToListAsync();
        }
    }

    internal interface ICampaignRepository
    {
    }
}