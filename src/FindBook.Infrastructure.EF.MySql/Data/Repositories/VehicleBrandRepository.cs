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

    public class VehicleBrandRepository: BaseRepository<VehicleBrand>, IVehicleBrandRepository
    {
        
        public VehicleBrandRepository(AracaParcaContext context, ILogger<VehicleBrandRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<VehicleBrand>> GetVehiclesBrand()
        {
            return await Table.Where(x=>x.IsActive)
            .Include(x=>x.LanguageBasedInfos)
            .Include(x=>x.SeoInfos)
            .ToListAsync();
        }

        public async Task<VehicleBrand> GetVehiclesBrandWithId(int id)
        {
            return await Table.Where(x=>x.Id == id).Include(x=>x.LanguageBasedInfos).FirstOrDefaultAsync();
        }
    }


}