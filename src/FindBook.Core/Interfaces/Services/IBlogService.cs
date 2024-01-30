using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Interfaces.Services
{

    public interface IBlogService:IBaseService<BlogDto>
    {
        Task<Response<List<BlogDto>>> GetBlogsWithFilter(FilterBlogDto blogDto,int languageId);
        Task<Response<BlogDto>> GetBlogWithId(int blogId,int languageId);
        Task<Response<List<BlogDto>>> GetBlogs(int languageId);
        Task<Response<BlogDto>> GetBlogWithSeoLink(string seolink,int languageId);

        


        


        
            
    }


}