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

    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {

        public ProductCategoryRepository(AracaParcaContext context, ILogger<ProductCategoryRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<ProductCategory>> GetAllCategory()
        {
            return await Table.Where(x => x.MainCategoryId == null)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.SeoInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.SeoInfos)

            .ToListAsync();
        }

        public async Task<ProductCategory> GetAllCategoryForCategoryDetail(int categoryId)
        {
            return await Table.Where(x => x.IsActive && x.Id == categoryId)
                .Include(x => x.MainCategory).ThenInclude(x => x.LanguageBasedInfos)
                .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
                .Include(x => x.ChildCategory).ThenInclude(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
                .Include(x => x.LanguageBasedInfos)
                .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetAllCategoryIds()
        {
            return await Table.Where(x => x.IsActive == true).Select(x => x.Id).ToListAsync();

        }

        public async Task<ProductCategory> GetBreadCrumb(int categoryId)
        {
            return await Table.Where(x => x.IsActive && x.Id == categoryId)
            .Include(x => x.MainCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.MainCategory).ThenInclude(x => x.SeoInfos)
            .Include(x => x.SeoInfos)
            .Include(x => x.LanguageBasedInfos)
            .FirstOrDefaultAsync();

        }

        public async Task<List<ProductCategory>> GetCategory(int categoryId)
        {
            return await Table.Where(x => x.Id == categoryId)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.SeoInfos)
            .ToListAsync();
        }

        public async Task<List<ProductCategory>> GetCategory(string text)
        {
            return await Table.Where(x => x.IsActive && x.LanguageBasedInfos.Where(y=>y.Name.Contains(text)).Count() > 0)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.MainCategory).ThenInclude(x => x.LanguageBasedInfos)
            .ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryForSearchResult(int categoryId)
        {
            return await Table.Where(x => x.Id == categoryId)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.SeoInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.SeoInfos)
            .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetCategoryIds(List<int> categoryIds)
        {
            return await Table.Where(x => x.IsActive == true && x.MainCategoryId != null && categoryIds.Contains((int)x.MainCategoryId)).Select(x => x.Id).ToListAsync();
        }

        public async Task<List<ProductCategory>> GetMainCategory()
        {
            return await Table.Where(x=>x.IsActive && x.MainCategoryId == null)
            .Include(x=>x.ChildCategory).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x=>x.LanguageBasedInfos).ToListAsync();
        }
    }


}