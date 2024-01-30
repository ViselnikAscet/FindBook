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

    public class CustomerCarRepository: BaseRepository<CustomerCar>, ICustomerCarRepository
    {
        
        public CustomerCarRepository(AracaParcaContext context, ILogger<CustomerCarRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<CustomerCar>> GetMyGarage(int customerId)
        {
            return await Table.Where(x=>x.CustomerId == customerId && x.IsActive)
            .Include(x=>x.Vehicle).ThenInclude(x=>x.VehicleBrand).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x=>x.Vehicle).ThenInclude(x=>x.VehicleModel).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x=>x.Vehicle).ThenInclude(x=>x.VehicleEngineCode).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x=>x.Vehicle).ThenInclude(x=>x.VehicleYear)
            .ToListAsync();
        }
    }


}