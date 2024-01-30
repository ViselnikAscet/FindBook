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

    public class ShipmentCompanyRepository: BaseRepository<ShipmentCompany>, IShipmentCompanyRepository
    {
        
        public ShipmentCompanyRepository(AracaParcaContext context, ILogger<ShipmentCompanyRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<ShipmentCompany>> GetAllShipment()
        {
           return await Table.ToListAsync();
        }

        public async Task<ShipmentCompany> GetShipmentWithId(int id)
        {
            return await Table.Where(x=> x.Id == id && x.IsActive == true)
            .Include(x=>x.ShipmentCompanyParameters)
            .FirstOrDefaultAsync();
        }
    }


}