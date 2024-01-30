using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface ILanguageBasedInfoRepository:IBaseRepository<LanguageBasedInfo>
    {
        Task<LanguageBasedInfo> GetProductInfo(int productId);
        Task<LanguageBasedInfo> GetVehicleInfo(int vehicleId , int languageId);
        Task<List<LanguageBasedInfo>> GetVehicleAllLangBasedInfos(int vehicleId);
        Task<List<LanguageBasedInfo>> GetMenuItemAllLangBasedInfos(int menutItemId);
        Task<List<LanguageBasedInfo>> GetCampaignLanguageBasedInfos(int campaignId);



        
    }
}