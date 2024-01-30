using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models;
using AracaParca.Core.Models.Dto.Product;
using AracaParca.Core.Models.Enum;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(AracaParcaContext context, ILogger<ProductRepository> logger) : base(context, logger)
        {

        }

        public async Task<bool> CheckCode(string searchText)
        {
            return (await Table.Where(x => x.Code == searchText).CountAsync()) > 0;
        }

        public async Task<List<Product>> GetElasticData()
        {
            return await Table
            .Include(x => x.ProductCategory)
            .ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.SeoInfos)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.Oems)
            .Include(x => x.Brand)
            .Include(x => x.SeoInfos)
            .Include(x => x.ProductVehicles)
            .Include(x => x.ProductPrices)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<List<Product>> GetProduct(SearchProductDto productDto)
        {
            return await Table.Where(x => x.IsActive && (x.Code.Contains(productDto.SearchText.ToUpper()) || x.LanguageBasedInfos.Where(y => y.Name.Contains(productDto.SearchText)).Count() > 0 || x.Oems.Where(y => y.OemCode.Contains(productDto.SearchText)).Count() > 0))
            .Include(x=>x.LanguageBasedInfos)
            .Include(x=>x.ProductPrices)
            .ToListAsync();
        }

        public async Task<Product> GetProductDetail(string url, int languageId)
        {
            return await Table.Where(x => x.IsActive && x.SeoInfos.Where(y => y.SeoLink.Contains(url)).Count() > 0)
            .Include(x => x.LanguageBasedInfos.Where(y => y.LanguageId == languageId))
            .Include(x => x.Oems).ThenInclude(c => c.Brand)
            .Include(x => x.Brand).ThenInclude(z => z.LanguageBasedInfo)
            .Include(x => x.ProductPrices.Where(c => c.PriceType == Core.Models.Enum.PriceType.SalesPrice && c.IsActive)).ThenInclude(c => c.Currency)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductQuantities)
            .Include(x => x.ProductVehicles)
            .Include(x => x.ProductCategory).ThenInclude(z => z.ChildCategory)
            .Include(x => x.ProductCategory).ThenInclude(z => z.LanguageBasedInfos.Where(y => y.LanguageId == languageId)).FirstOrDefaultAsync();
        }

        // 
        public async Task<List<Product>> GetProductWithElk(List<int> productIds)
        {
            return await Table.Where(x => productIds.Contains(x.Id))
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.Oems)
            .Include(x => x.Brand).ThenInclude(z => z.LanguageBasedInfo)
            .Include(x => x.ProductPrices)
            .Include(x => x.ProductImages)
            .Include(x => x.ProductQuantities)
            .Include(x => x.ProductVehicles)
            .Include(x => x.ProductCategory).ThenInclude(z => z.LanguageBasedInfos)
            .ToListAsync();
        }

        public async Task<List<Product>> GetProductWithElkSearchResult(List<int> idList , OrderBy order)
        {

            var result = Table.Where(x => idList.Contains(x.Id))
                .Include(x => x.LanguageBasedInfos)
                .Include(x => x.Oems)
                .Include(x => x.Brand).ThenInclude(x=>x.LanguageBasedInfo)
                .Include(x => x.ProductPrices.Where(x=>x.PriceType == PriceType.SalesPrice && x.IsActive)).ThenInclude(x=>x.Currency)
                .Include(x => x.ProductImages)
                .Include(x => x.SeoInfos);

                switch (order)
                {
                    case OrderBy.Default:
                        //result.OrderBy(x=>x.ProductPrices.Where(x=>x.IsActive && x.PriceType==PriceType.SalesPrice).FirstOrDefault().Price);
                        break;
                    case OrderBy.IncreasedPrice:
                        result.OrderBy(x=>x.ProductPrices.Where(x=>x.IsActive && x.PriceType==PriceType.SalesPrice).FirstOrDefault().Price);
                        break;
                    case OrderBy.DecreasingPrice:
                        result.OrderByDescending(x=>x.ProductPrices.Where(x=>x.IsActive && x.PriceType==PriceType.SalesPrice).FirstOrDefault().Price);
                        break;
                    case OrderBy.NewAdded:
                        result.OrderByDescending(x=>x.CreatedAt);
                        break;
                    case OrderBy.MostSold:
                        result.OrderBy(x=>x.OrderDetails.Count);
                        break;
                    case OrderBy.MostStar:
                        break;
                    default:
                        break;
                }
               
            return await result
                .AsNoTracking()
                .ToListAsync();
        }
    }
}