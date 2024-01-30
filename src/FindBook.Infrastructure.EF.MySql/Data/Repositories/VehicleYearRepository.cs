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

    public class VehicleYearRepository: BaseRepository<VehicleYear>, IVehicleYearRepository
    {
        
        public VehicleYearRepository(AracaParcaContext context, ILogger<VehicleYearRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<VehicleYear>> GetVehiclesModel(int enginecodeId)
        {
            return await Table.Where(x=>x.IsActive && x.VehicleEngineCodeId == enginecodeId).Include(x=>x.LanguageBasedInfos).ToListAsync();
        }
    }


}