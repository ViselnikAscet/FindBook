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

    public class BrandRepository: BaseRepository<Brand>, IBrandRepository
    {
        
        public BrandRepository(AracaParcaContext context, ILogger<BrandRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<List<Brand>> GetBrandsIfHasCategoryId(List<int> categoryIdList)
        {
            return await Table.Where(x=>x.Products.Where(y=>categoryIdList.Contains(y.ProductCategoryId)).ToList().Count>0).ToListAsync(); 
        }
    }


}