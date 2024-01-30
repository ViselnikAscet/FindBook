using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.CampaignDetail;

namespace FindBook.Core.Interfaces.Services
{

    public interface ICampaignDetailService:IBaseService<CampaignDetailDto>
    {
        

                Task<Response<List<CampaignDetailDto>>> GetCampaignDetail(int campaignId , int languageId);
    }


}