using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Campaign;

namespace FindBook.Core.Interfaces.Services
{

    public interface ICampaignService:IBaseService<CampaignDto>
    {
        
         Task<Response<List<CampaignDto>>> GetAllCampaigns( int languageId);
        
    }


}