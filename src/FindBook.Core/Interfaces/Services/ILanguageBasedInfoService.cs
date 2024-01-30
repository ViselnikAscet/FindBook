using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.LanguageBasedInfo;

namespace FindBook.Core.Interfaces.Services
{

    public interface ILanguageBasedInfoService:IBaseService<LanguageBasedInfoDto>
    {
        Task<Response<LanguageBasedInfoDto>> GetProductInfo(int productId,int languageId);
        Task<Response<LanguageBasedInfoDto>> GetVehicleInfo(int vehicleId,int languageId);
        Task<Response<List<LanguageBasedInfoDto>>> GetVehicleAllLangBasedInfos(int vehicleId,int languageId);
        Task<Response<List<LanguageBasedInfoDto>>> GetMenuItemAllLangBasedInfos(int menuItemId,int languageId);
        Task<Response<List<LanguageBasedInfoDto>>> GetCampaignLanguageBasedInfos(int campaignId,int languageId);


        


        
    }


}