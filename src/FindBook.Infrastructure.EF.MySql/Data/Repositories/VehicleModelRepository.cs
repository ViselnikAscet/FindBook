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

    public class VehicleModelRepository: BaseRepository<VehicleModel>, IVehicleModelRepository
    {
        
        public VehicleModelRepository(AracaParcaContext context, ILogger<VehicleModelRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<VehicleModel>> GetVehiclesModel(int brandId)
        {
           return await Table.Where(x=>x.IsActive && x.VehicleBrandId == brandId).Include(x=>x.LanguageBasedInfos).ToListAsync();
        }
    }


}