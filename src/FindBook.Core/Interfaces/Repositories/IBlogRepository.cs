using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Models.Dto.Blog;

namespace FindBook.Core.Interfaces.Repositories
{
    public interface IBlogRepository : IBaseRepository<Blog>
    {

        Task<List<Blog>> GetBlogsWithFilter(FilterBlogDto blogdto);
        Task<Blog> GetBlogWithId(int blogId);
        Task<List<Blog>> GetBlogs();

        


    }
}