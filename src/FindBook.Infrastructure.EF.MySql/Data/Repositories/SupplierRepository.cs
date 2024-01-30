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

    public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
    {
        
        public SupplierRepository(AracaParcaContext context, ILogger<SupplierRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<Supplier> GetSupplierDetail(int supplierId)
        {
            return await Table.Where(x=>x.Id == supplierId)
            .Include(x=>x.OrderDetails)
            .Include(x=>x.Warehouses)
            .FirstOrDefaultAsync();
        }

        public async Task<List<Supplier>> GetSuppliers(string suppliersName)
        {
            return await Table.Where(x=>x.IsActive && x.Name.Contains(suppliersName)).ToListAsync();
        }
    }


}