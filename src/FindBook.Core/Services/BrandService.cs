using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Brand;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class BrandService : BaseService<Brand, BrandDto>, IBrandService
    {
        private protected readonly IBrandRepository _brandRepository;
        private readonly IProductCategoryService _productCategoryService;


        public BrandService(
            ILogger<BrandService> logger,
            IMapper mapper,
            IBrandRepository repository,
            IValidator<BrandDto> validator,
            IProductCategoryService productCategoryService,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productCategoryService = productCategoryService;
            _brandRepository = repository;
        }


        public async Task<Response<List<BrandDto>>> GetBrandsIfHasCategoryId(int categoryId, int languageId)
        {
            Response<List<BrandDto>> response = new Response<List<BrandDto>>();

            List<int> subCategoryProductIdList = await _productCategoryService.GetCategoryIds(categoryId, languageId); // gelen kategorinin alt kategori id listesi

            var data = await _brandRepository.GetBrandsIfHasCategoryId(subCategoryProductIdList);

            if(data != null){
                response.Data = Mapper.Map<List<BrandDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }
    }


}