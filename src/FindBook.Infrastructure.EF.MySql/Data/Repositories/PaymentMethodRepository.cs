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

    public class PaymentMethodRepository: BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        
        public PaymentMethodRepository(AracaParcaContext context, ILogger<PaymentMethodRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<PaymentMethod>> GetAll()
        {
            return await Table.Where(x=>x.IsActive).ToListAsync();
        }
    }


}