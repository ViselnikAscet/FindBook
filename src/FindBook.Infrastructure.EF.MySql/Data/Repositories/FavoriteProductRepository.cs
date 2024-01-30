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

    public class FavoriteProductRepository : BaseRepository<FavoriteProduct>, IFavoriteProductRepository
    {

        public FavoriteProductRepository(AracaParcaContext context, ILogger<FavoriteProductRepository> logger) : base(context, logger)
        {

        }


        public async Task<List<FavoriteProduct>> GetFavoriteProduct(int customerId, int languageId)
        {

            return await Table.Where(x => x.IsActive && x.CustomerId == customerId)
                .Include(x => x.Product).ThenInclude(x => x.Brand)
                .Include(x => x.Product).ThenInclude(x => x.ProductImages)
                .Include(x => x.Product).ThenInclude(x => x.ProductQuantities)
                .Include(x=>x.Product).ThenInclude(x=>x.SeoInfos)
                .Include(x => x.Product).ThenInclude(x => x.ProductPrices.Where(c => c.IsActive && c.PriceType == Core.Models.Enum.PriceType.SalesPrice)).ThenInclude(x=>x.Currency)
                .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos.Where(c => c.IsActive && c.LanguageId == languageId))
                .ToListAsync();
        }
    }


}