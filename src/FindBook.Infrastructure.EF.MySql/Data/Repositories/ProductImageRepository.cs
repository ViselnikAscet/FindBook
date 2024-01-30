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

    public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {

        public ProductImageRepository(AracaParcaContext context, ILogger<ProductImageRepository> logger) : base(context, logger)
        {

        }

      
    }


}