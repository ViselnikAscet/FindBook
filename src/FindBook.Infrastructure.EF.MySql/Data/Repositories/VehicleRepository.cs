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
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {

        public VehicleRepository(AracaParcaContext context, ILogger<VehicleRepository> logger) : base(context, logger)
        {

        }

        public async Task<Vehicle> GetVehicleId(SimpleVehicleDto vehicleDto)
        {
            return await Table.Where(x => x.VehicleBrandId == vehicleDto.VehicleBrandId && x.VehicleModelId == vehicleDto.VehicleModelId && x.VehicleEngineCodeId == vehicleDto.VehicleEngineCodeId && x.VehicleYearId == vehicleDto.VehicleEngineYearId).FirstOrDefaultAsync();
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await Table.Where(x => x.IsActive)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleYear)
            .Include(x => x.ProductVehicles)
            .Include(x => x.VehicleBrand)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleEngineCode).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleModel).ThenInclude(x => x.LanguageBasedInfos)
            .ToListAsync();
        }

        public async Task<Vehicle> GetVehicleWithId(int id)
        {
            return await Table.Where(x => x.Id == id)
            .Include(x => x.VehicleBrand)
            .Include(x => x.VehicleModel)
            .Include(x => x.VehicleEngineCode)
            .Include(x => x.VehicleYear)
            .FirstOrDefaultAsync();
        }

        public async Task<List<Vehicle>> GetVehicleWithParameters(SimpleVehicleDto simpleVehicleDto, int languageId)
        {
            return await Table
             .Where(x =>
            (
            ((simpleVehicleDto.VehicleBrandId != -1 && simpleVehicleDto.VehicleBrandId == x.VehicleBrandId) || (simpleVehicleDto.VehicleBrandId == -1))
             &&
            ((simpleVehicleDto.VehicleModelId != -1 && simpleVehicleDto.VehicleModelId == x.VehicleModelId) || (simpleVehicleDto.VehicleModelId == -1))
            &&
            ((simpleVehicleDto.VehicleEngineCodeId != -1 && simpleVehicleDto.VehicleEngineCodeId == x.VehicleEngineCodeId) || (simpleVehicleDto.VehicleEngineCodeId == -1))
            &&
            ((simpleVehicleDto.VehicleEngineYearId != -1 && simpleVehicleDto.VehicleEngineYearId == x.VehicleEngineYearId) || (simpleVehicleDto.VehicleEngineYearId == -1))
            )
        )
        .Include(x=>x.VehicleBrand).ThenInclude(x=>x.LanguageBasedInfos)
        .Include(x=>x.VehicleModel).ThenInclude(x=>x.LanguageBasedInfos)
        .Include(x=>x.VehicleYear)
        .Include(x=>x.VehicleEngineCode).ThenInclude(x=>x.LanguageBasedInfos)
        .ToListAsync();
        }
    }


}