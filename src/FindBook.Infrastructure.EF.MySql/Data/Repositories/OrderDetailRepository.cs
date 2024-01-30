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

    public class OrderDetailRepository: BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        
        public OrderDetailRepository(AracaParcaContext context, ILogger<OrderDetailRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<OrderDetail>> GetAllOrderDetailForOrderId(int orderId)
        {
            return await Table.Where(x=>x.IsActive && x.OrderId == orderId).ToListAsync();
        }
    }


}