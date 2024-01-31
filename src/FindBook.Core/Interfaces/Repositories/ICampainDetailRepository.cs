using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Models.Dto.Blog;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface ICampaignDetailRepository : IBaseRepository<CampaignDetail>
    {

         Task<List<CampaignDetail>> GetCampaignDetail(int campaignId);


    }
}