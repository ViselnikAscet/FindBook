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

    public class ShipmentMethodValueRepository: BaseRepository<ShipmentMethodValue>, IShipmentMethodValueRepository
    {
        
        public ShipmentMethodValueRepository(AracaParcaContext context, ILogger<ShipmentMethodValueRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<ShipmentMethodValue> GetShipmentMethodValueWithMethodId(int shipmentMethodId)
        {
            return await Table.Where(x=>x.ShipmentMethodId == shipmentMethodId && x.IsActive).AsNoTracking().FirstOrDefaultAsync();
        }
    }


}