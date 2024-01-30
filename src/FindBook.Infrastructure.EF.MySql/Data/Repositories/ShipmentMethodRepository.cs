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

    public class ShipmentMethodRepository: BaseRepository<ShipmentMethod>, IShipmentMethodRepository
    {
        
        public ShipmentMethodRepository(AracaParcaContext context, ILogger<ShipmentMethodRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<ShipmentMethod>> GetAllShipmentMethod(int id, int languageId)
        {
            return await Table.Where(x=>x.ShipmentCompanyId == id).ToListAsync();
        }
    }


}