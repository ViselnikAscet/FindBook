using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Basket;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class BlogService : BaseService<Blog, BlogDto>, IBlogService
    {
        private protected readonly IBlogRepository _blogRepository;
        private readonly ISeoInfoRepository _seoInfoRepository;

        public BlogService(
            ILogger<BlogService> logger,
            IMapper mapper,
            IBlogRepository repository,
            ISeoInfoRepository seoInfoRepository,
            IValidator<BlogDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _blogRepository = repository;
            _seoInfoRepository = seoInfoRepository;

        }

        public async Task<Response<List<BlogDto>>> GetBlogs(int languageId)
        {
            Response<List<BlogDto>> response = new Response<List<BlogDto>>();
            var data = await _blogRepository.GetBlogs();

            if (data != null)
            {
                response.Data = Mapper.Map<List<BlogDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8004", languageId));
            }

            return response;
        }

        public async Task<Response<List<BlogDto>>> GetBlogsWithFilter(FilterBlogDto blogdto, int languageId)
        {
            Response<List<BlogDto>> response = new Response<List<BlogDto>>();

            var data = await _blogRepository.GetBlogsWithFilter(blogdto);

            if (data != null)
            {
                response.Data = Mapper.Map<List<BlogDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8004", languageId));
            }

            return response;
        }

        public async Task<Response<BlogDto>> GetBlogWithId(int blogId, int languageId)
        {
            Response<BlogDto> response = new Response<BlogDto>();

            var data = await _blogRepository.GetBlogWithId(blogId);

            if (data != null)
            {
                response.Data = Mapper.Map<BlogDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8004", languageId));
            }

            return response;
        }

        public async Task<Response<BlogDto>> GetBlogWithSeoLink(string seolink, int languageId)
        {
            Response<BlogDto> response = new Response<BlogDto>();

            var data = await _seoInfoRepository.GetBlogWithSeoLink(seolink);

            if (data != null)
            {
                var blogData = await _blogRepository.GetBlogWithId((int)data.BlogId);
                if (blogData != null)
                {
                    response.Data = Mapper.Map<BlogDto>(blogData);
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = false;
                }

            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }
    }


}