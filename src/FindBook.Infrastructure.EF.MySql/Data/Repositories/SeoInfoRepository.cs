using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Vehicle;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class SeoInfoRepository: BaseRepository<SeoInfo>, ISeoInfoRepository
    {
        
        public SeoInfoRepository(AracaParcaContext context, ILogger<SeoInfoRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<SeoInfo> GetBlogWithSeoLink(string seolink)
        {
           return await Table.Where(x=>x.SeoLink == seolink).FirstOrDefaultAsync();
        }

        public async Task<SeoInfo> GetSeoDataWithLink(string link)
        {
            return await Table.Where(x=>x.SeoLink == link && x.IsActive)
            .FirstOrDefaultAsync();
        }

        public async Task<SeoInfo> GetSeoLinkWithVehicleData(int vehicleId)
        {
            return await Table.Where(x=>x.VehicleId == vehicleId && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<SeoInfo> GetSeoLinkWithVehicleData(SimpleVehicleDto vehicleDto)
        {
            return await Table
            .Where(
                x=> x.VehicleBrandId == vehicleDto.VehicleBrandId &&
                x.VehicleModelId == vehicleDto.VehicleModelId &&
                x.VehicleEngineCodeId == vehicleDto.VehicleEngineCodeId &&
                x.VehicleYearId == vehicleDto.VehicleEngineYearId
                ).FirstOrDefaultAsync();
        }

        public async Task<SeoInfo> GetSeoWithCategoryId(int categoryId)
        {
            return await Table.Where(x=>x.IsActive && x.ProductCategoryId == categoryId).FirstOrDefaultAsync();
        }
    }


}