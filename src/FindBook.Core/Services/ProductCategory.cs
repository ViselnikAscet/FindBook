using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ProductCategory;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ProductCategoryService : BaseService<ProductCategory, ProductCategoryDto>, IProductCategoryService
    {
        private protected readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(
            ILogger<ProductCategoryService> logger,
            IMapper mapper,
            IProductCategoryRepository repository,
            IValidator<ProductCategoryDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productCategoryRepository = repository;
        }

        public async Task<List<int>> GetCategoryIds(int categoryId, int languageId)
        {
            List<int> categoryIds = new List<int>();
            categoryIds.Add(categoryId);

            List<int> tmpIdList = new List<int>();
            tmpIdList.Add(categoryId);

            bool isContinue = true;

            do
            {
                var data = await _productCategoryRepository.GetCategoryIds(tmpIdList);

                if (data.Count == 0)
                {
                    isContinue = false;
                }
                else
                {
                    tmpIdList = data;
                    categoryIds.AddRange(data);
                }

            } while (isContinue);


            return categoryIds;
        }

        public async Task<Response<List<ProductCategoryDto>>> GetCategory(int categoryId, int languageId)
        {
            Response<List<ProductCategoryDto>> response = new Response<List<ProductCategoryDto>>();

            var data = await _productCategoryRepository.GetCategory(categoryId);
            response.Data = Mapper.Map<List<ProductCategoryDto>>(data);

            return response;
        }

        public async Task<Response<List<ProductCategoryDto>>> GetBreadCrumb(int categoryId, int languageId)
        {
            Response<List<ProductCategoryDto>> response = new Response<List<ProductCategoryDto>>();
            response.Data = new List<ProductCategoryDto>();
            response.IsSuccess = true;
            bool isContinue = true;

            var data = await _productCategoryRepository.GetBreadCrumb(categoryId);
            response.Data.Add(Mapper.Map<ProductCategoryDto>(data));

            do
            {

                if (data.MainCategory == null)
                {

                    isContinue = false;
                }
                else
                {
                    data = await _productCategoryRepository.GetBreadCrumb((int)data.MainCategoryId);

                    response.Data.Add(Mapper.Map<ProductCategoryDto>(data));
                }

            } while (isContinue);


            return response;
        }

        public async Task<Response<List<ProductCategoryDto>>> GetAllCategory(int languageId)
        {
            Response<List<ProductCategoryDto>> response = new Response<List<ProductCategoryDto>>();

            var data = await _productCategoryRepository.GetAllCategory();

            if (data != null)
            {
                response.Data = Mapper.Map<List<ProductCategoryDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<Response<ProductCategoryDto>> GetCategoryForSearchResult(int categoryId, int languageId)
        {
            Response<ProductCategoryDto> response = new Response<ProductCategoryDto>();

            var data = await _productCategoryRepository.GetCategoryForSearchResult(categoryId);

            if (data != null)
            {
                response.Data = Mapper.Map<ProductCategoryDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<List<int>> GetAllCategoryIds(int languageId)
        {
            var data = await _productCategoryRepository.GetAllCategoryIds();

            return data;

        }

        public async Task<Response<List<ProductCategoryDto>>> GetCategory(string searchText, int languageId)
        {
            Response<List<ProductCategoryDto>> response = new Response<List<ProductCategoryDto>>();

            var data = await _productCategoryRepository.GetCategory(searchText);

            if (data != null)
            {
                response.Data = Mapper.Map<List<ProductCategoryDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7019", languageId));
            }

            return response;
        }

        public async Task<Response<List<ProductCategoryDto>>> GetAllCategoryForCategoryDetail(int categoryId, int languageId)
        {
            Response<List<ProductCategoryDto>> response = new Response<List<ProductCategoryDto>>();
            response.Data = new List<ProductCategoryDto>();
            response.IsSuccess = true;
            bool isContinue = true;

            var data = await _productCategoryRepository.GetAllCategoryForCategoryDetail(categoryId);
            // response.Data.Add(Mapper.Map<ProductCategoryDto>(data));

            do
            {
                if (data.MainCategory == null)
                {
                    var data2 = await _productCategoryRepository.GetMainCategory();

                    foreach (var item in data2)
                    {
                        if (response.Data.FindIndex(x => x.Id == item.Id) == -1)
                        {
                            response.Data.Add(Mapper.Map<ProductCategoryDto>(item));
                        }
                    }

                    isContinue = false;
                }
                else
                {
                    data = await _productCategoryRepository.GetAllCategoryForCategoryDetail((int)data.MainCategoryId);
                    response.Data.Add(Mapper.Map<ProductCategoryDto>(data));
                    foreach (var item in data.ChildCategory)
                    {
                        item.LanguageBasedInfos[0].Name = " -- " + item.LanguageBasedInfos[0].Name;
                        response.Data.Add(Mapper.Map<ProductCategoryDto>(item));
                        foreach (var child in item.ChildCategory)
                        {
                            child.LanguageBasedInfos[0].Name = " -- -- " + child.LanguageBasedInfos[0].Name;
                            response.Data.Add(Mapper.Map<ProductCategoryDto>(child));
                        }
                    }
                    if (data.MainCategoryId != null)
                    {
                        data = await _productCategoryRepository.GetAllCategoryForCategoryDetail((int)data.MainCategoryId);
                        foreach (var item in data.ChildCategory)
                        {
                            response.Data.Add(Mapper.Map<ProductCategoryDto>(item));
                        }
                    }

                }
            } while (isContinue);


            return response;
        }
    }


}
