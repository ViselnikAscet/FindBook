using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.BookCategory;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class BookCategoryService : BaseService<BooksCategory, BookCategoryDto>
    {
        private protected readonly IBooksCategoryRepository _BookCategoryRepository;

        public BookCategoryService(
            ILogger<BookCategoryService> logger,
            IMapper mapper,
            IBooksCategoryRepository repository,
            IValidator<BookCategoryDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _BookCategoryRepository = repository;
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
                var data = await _BookCategoryRepository.GetCategoryIds(tmpIdList);

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

        public async Task<Response<List<BookCategoryDto>>> GetCategory(int categoryId, int languageId)
        {
            Response<List<BookCategoryDto>> response = new Response<List<BookCategoryDto>>();

            var data = await _BookCategoryRepository.GetCategory(categoryId);
            response.Data = Mapper.Map<List<BookCategoryDto>>(data);

            return response;
        }

        public async Task<Response<List<BookCategoryDto>>> GetBreadCrumb(int categoryId, int languageId)
        {
            Response<List<BookCategoryDto>> response = new Response<List<BookCategoryDto>>();
            response.Data = new List<BookCategoryDto>();
            response.IsSuccess = true;
            bool isContinue = true;

            var data = await _BookCategoryRepository.GetBreadCrumb(categoryId);
            response.Data.Add(Mapper.Map<BookCategoryDto>(data));

            do
            {

                if (data.MainCategory == null)
                {

                    isContinue = false;
                }
                else
                {
                    data = await _BookCategoryRepository.GetBreadCrumb((int)data.MainCategoryId);

                    response.Data.Add(Mapper.Map<BookCategoryDto>(data));
                }

            } while (isContinue);


            return response;
        }

        public async Task<Response<List<BookCategoryDto>>> GetAllCategory(int languageId)
        {
            Response<List<BookCategoryDto>> response = new Response<List<BookCategoryDto>>();

            var data = await _BookCategoryRepository.GetAllCategory();

            if (data != null)
            {
                response.Data = Mapper.Map<List<BookCategoryDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<Response<BookCategoryDto>> GetCategoryForSearchResult(int categoryId, int languageId)
        {
            Response<BookCategoryDto> response = new Response<BookCategoryDto>();

            var data = await _BookCategoryRepository.GetCategoryForSearchResult(categoryId);

            if (data != null)
            {
                response.Data = Mapper.Map<BookCategoryDto>(data);
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
            var data = await _BookCategoryRepository.GetAllCategoryIds();

            return data;

        }

        public async Task<Response<List<BookCategoryDto>>> GetCategory(string searchText, int languageId)
        {
            Response<List<BookCategoryDto>> response = new Response<List<BookCategoryDto>>();

            var data = await _BookCategoryRepository.GetCategory(searchText);

            if (data != null)
            {
                response.Data = Mapper.Map<List<BookCategoryDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7019", languageId));
            }

            return response;
        }

        public async Task<Response<List<BookCategoryDto>>> GetAllCategoryForCategoryDetail(int categoryId, int languageId)
        {
            Response<List<BookCategoryDto>> response = new Response<List<BookCategoryDto>>();
            response.Data = new List<BookCategoryDto>();
            response.IsSuccess = true;
            bool isContinue = true;

            var data = await _BookCategoryRepository.GetAllCategoryForCategoryDetail(categoryId);
            // response.Data.Add(Mapper.Map<BookCategoryDto>(data));

            do
            {
                if (data.MainCategory == null)
                {
                    var data2 = await _BookCategoryRepository.GetMainCategory();

                    foreach (var item in data2)
                    {
                        if (response.Data.FindIndex(x => x.Id == item.Id) == -1)
                        {
                            response.Data.Add(Mapper.Map<BookCategoryDto>(item));
                        }
                    }

                    isContinue = false;
                }
                else
                {
                    data = await _BookCategoryRepository.GetAllCategoryForCategoryDetail((int)data.MainCategoryId);
                    response.Data.Add(Mapper.Map<BookCategoryDto>(data));
                    foreach (var item in data.ChildCategory)
                    {
                        item.LanguageBasedInfos[0].Name = " -- " + item.LanguageBasedInfos[0].Name;
                        response.Data.Add(Mapper.Map<BookCategoryDto>(item));
                        foreach (var child in item.ChildCategory)
                        {
                            child.LanguageBasedInfos[0].Name = " -- -- " + child.LanguageBasedInfos[0].Name;
                            response.Data.Add(Mapper.Map<BookCategoryDto>(child));
                        }
                    }
                    if (data.MainCategoryId != null)
                    {
                        data = await _BookCategoryRepository.GetAllCategoryForCategoryDetail((int)data.MainCategoryId);
                        foreach (var item in data.ChildCategory)
                        {
                            response.Data.Add(Mapper.Map<BookCategoryDto>(item));
                        }
                    }

                }
            } while (isContinue);


            return response;
        }
    }


}
