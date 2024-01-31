using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class ProductCategoryRepository : BaseRepository<BooksCategory>, IBooksCategoryRepository
    {

        public ProductCategoryRepository(FindBookContext context, ILogger<ProductCategoryRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<BooksCategory>> GetAllCategory()
        {
            return await Table.Where(x => x.MainCategoryId == null)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)

            .ToListAsync();
        }

        public async Task<BooksCategory> GetAllCategoryForCategoryDetail(int categoryId)
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

        public async Task<BooksCategory> GetBreadCrumb(int categoryId)
        {
            return await Table.Where(x => x.IsActive && x.Id == categoryId)
            .Include(x => x.MainCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.LanguageBasedInfos)
            .FirstOrDefaultAsync();

        }

        public async Task<List<BooksCategory>> GetCategory(int categoryId)
        {
            return await Table.Where(x => x.Id == categoryId)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
            .ToListAsync();
        }

        public async Task<List<BooksCategory>> GetCategory(string text)
        {
            return await Table.Where(x => x.IsActive && x.LanguageBasedInfos.Where(y=>y.Name.Contains(text)).Count() > 0)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.MainCategory).ThenInclude(x => x.LanguageBasedInfos)
            .ToListAsync();
        }

        public async Task<BooksCategory> GetCategoryForSearchResult(int categoryId)
        {
            return await Table.Where(x => x.Id == categoryId)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.ChildCategory).ThenInclude(x => x.LanguageBasedInfos)
            .FirstOrDefaultAsync();
        }

        public async Task<List<int>> GetCategoryIds(List<int> categoryIds)
        {
            return await Table.Where(x => x.IsActive == true && x.MainCategoryId != null && categoryIds.Contains((int)x.MainCategoryId)).Select(x => x.Id).ToListAsync();
        }

        public async Task<List<BooksCategory>> GetMainCategory()
        {
            return await Table.Where(x=>x.IsActive && x.MainCategoryId == null)
            .Include(x=>x.ChildCategory).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x=>x.LanguageBasedInfos).ToListAsync();
        }

        Task<List<BooksCategory>> IBooksCategoryRepository.GetAllCategory()
        {
            throw new NotImplementedException();
        }

        Task<BooksCategory> IBooksCategoryRepository.GetAllCategoryForCategoryDetail(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<BooksCategory> IBooksCategoryRepository.GetBreadCrumb(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<List<BooksCategory>> IBooksCategoryRepository.GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<List<BooksCategory>> IBooksCategoryRepository.GetCategory(string text)
        {
            throw new NotImplementedException();
        }

        Task<BooksCategory> IBooksCategoryRepository.GetCategoryForSearchResult(int categoryId)
        {
            throw new NotImplementedException();
        }

        Task<List<BooksCategory>> IBooksCategoryRepository.GetMainCategory()
        {
            throw new NotImplementedException();
        }
    }


}