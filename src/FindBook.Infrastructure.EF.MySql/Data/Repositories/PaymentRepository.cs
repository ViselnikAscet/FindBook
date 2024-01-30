using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class PaymentRepository: BaseRepository<Payment>, IPaymentRepository
    {
        
        public PaymentRepository(AracaParcaContext context, ILogger<PaymentRepository> logger) : base(context, logger)
        {
            
        }


    }


}