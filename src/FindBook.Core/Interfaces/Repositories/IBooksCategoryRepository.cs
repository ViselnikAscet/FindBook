using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface IBooksCategoryRepository : IBaseRepository<BooksCategory>
    {
        Task<List<int>> GetCategoryIds(List<int> categoryIds);
        Task<List<int>> GetAllCategoryIds();

        Task<List<BooksCategory>> GetCategory(int categoryId);
        Task<BooksCategory> GetBreadCrumb(int categoryId);
        Task<List<BooksCategory>> GetAllCategory();
        Task<BooksCategory> GetCategoryForSearchResult(int categoryId);

        Task<List<BooksCategory>> GetCategory(string text);

        Task<BooksCategory> GetAllCategoryForCategoryDetail(int categoryId);
        Task<List<BooksCategory>> GetMainCategory();



    }
}