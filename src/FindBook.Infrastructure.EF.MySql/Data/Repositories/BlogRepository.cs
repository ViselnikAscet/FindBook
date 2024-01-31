using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {

        public BlogRepository(FindBookContext context, ILogger<BlogRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await Table.Where(x=>x.IsActive).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithFilter(FilterBlogDto blogDto)
        {
            return await Table
            .Where(
                x => x.Name.Contains(blogDto.Name) &&
                x.User.Id == blogDto.UserId
                //  &&
                // x.ShareStartDate < blogDto.ShareEndDate &&
                // x.ShareStartDate > blogDto.ShareStartDate
                )
            .Include(x => x.User)
            .ToListAsync();
        }

        public async Task<Blog> GetBlogWithId(int blogId)
        {
            return await Table.Where(x => x.Id == blogId)
            .FirstOrDefaultAsync();
        }
    }


}