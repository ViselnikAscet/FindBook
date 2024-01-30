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

    public class ShipmentCompanyParameterRepository: BaseRepository<ShipmentCompanyParameter>, IShipmentCompanyParameterRepository
    {
        
        public ShipmentCompanyParameterRepository(AracaParcaContext context, ILogger<ShipmentCompanyParameterRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<ShipmentCompanyParameter> CheckShipmentCompanyParameter(int id)
        {
            return await Table.Where(x=>x.ShipmentCompanyId == id && x.IsActive).FirstOrDefaultAsync();
        }
    }


}