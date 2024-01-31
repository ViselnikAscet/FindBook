using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface ICampaignRepository : IBaseRepository<Campaign>
    {

    
         Task<List<Campaign>> GetAllCampaigns( int languageId);

        


    }
}