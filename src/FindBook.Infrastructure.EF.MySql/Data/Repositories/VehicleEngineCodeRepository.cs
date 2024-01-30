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

    public class VehicleEngineCodeRepository: BaseRepository<VehicleEngineCode>, IVehicleEngineCodeRepository
    {
        
        public VehicleEngineCodeRepository(AracaParcaContext context, ILogger<VehicleEngineCodeRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<VehicleEngineCode>> GetVehiclesEngineCodes(int modelId)
        {
            return await Table.Where(x=>x.IsActive && x.VehicleModelId == modelId).Include(x=>x.LanguageBasedInfos).ToListAsync();
        }
    }


}