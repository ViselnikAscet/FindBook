using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models;
using AracaParca.Core.Models.Dto.Product;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class ProductPriceRepository : BaseRepository<ProductPrice>, IProductPriceRepository
    {

        public ProductPriceRepository(AracaParcaContext context, ILogger<ProductPriceRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<ProductPrice>> GetProductPrice(int productId)
        {
            return await Table.Where(x => x.ProductId == productId && x.PriceType == Core.Models.Enum.PriceType.BuyingPrice)
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Product).ThenInclude(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Supplier)
            .Include(x => x.Currency)
            .ToListAsync();
        }

        public async Task<List<ProductPrice>> GetProductPrice(int productId, int supplierId)
        {
            return await Table.Where(x => x.ProductId == productId && x.SupplierId == supplierId && x.PriceType == Core.Models.Enum.PriceType.BuyingPrice)
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Product).ThenInclude(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Supplier)
            .Include(x => x.Currency)
            .ToListAsync();
        }

        public async Task<List<ProductPrice>> GetSuppliersProduct(int supplierId)
        {
            return await Table.Where(x => x.IsActive && x.SupplierId == supplierId && x.PriceType == Core.Models.Enum.PriceType.BuyingPrice)
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Currency)
            .Take(20)
            .ToListAsync();
        }
    }


}