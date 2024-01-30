using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ProductPrice;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ProductPriceService : BaseService<ProductPrice, ProductPriceDto>, IProductPriceService
    {
        private protected readonly IProductPriceRepository _productPriceRepository;

        public ProductPriceService(
            ILogger<ProductPriceService> logger,
            IMapper mapper,
            IProductPriceRepository repository,
            IValidator<ProductPriceDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productPriceRepository = repository;
        }

        public async Task<Response<List<ProductPriceDto>>> GetProductPrice(int productId, int languageId)
        {
            Response<List<ProductPriceDto>> response = new Response<List<ProductPriceDto>>();
            var data = await _productPriceRepository.GetProductPrice(productId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<ProductPriceDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7023", languageId));

            }
            return response;
        }

        public async Task<Response<List<ProductPriceDto>>> GetProductPrice(int productId, int supid, int languageId)
        {
            Response<List<ProductPriceDto>> response = new Response<List<ProductPriceDto>>();
            var data = await _productPriceRepository.GetProductPrice(productId , supid);

            if (data != null)
            {
                response.Data = Mapper.Map<List<ProductPriceDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7023", languageId));

            }
            return response;
        }

        public async Task<Response<List<ProductPriceDto>>> GetSuppliersProduct(int supplierId, int languageId)
        {
            Response<List<ProductPriceDto>> response = new Response<List<ProductPriceDto>>();

            var data = await _productPriceRepository.GetSuppliersProduct(supplierId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<ProductPriceDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7022", languageId));
            }

            return response;
        }
    }


}