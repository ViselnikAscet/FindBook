using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Models.Enum;
using FindBook.Core.Services.Bases;
using AutoMapper;
using Elasticsearch.Net;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Nest;

namespace FindBook.Core.Services
{

    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        private protected readonly IProductRepository _productRepository;

        private protected readonly IBasketRepository _basketRepository;

        // private readonly IElasticClient _elasticClient;

        public ProductService(
            ILogger<ProductService> logger,
            IMapper mapper,
            IProductRepository repository,
            // IElasticClient elasticClient,
            IBasketRepository basketRepository,
            IValidator<ProductDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productRepository = repository;
            // _elasticClient = elasticClient;
            _basketRepository = basketRepository;
        }

        public async Task<Response<bool>> ChangeProductLayout(string layout, int languageId)
        {
            Response<bool> response = new Response<bool>();
            response.IsSuccess = true;
            response.Data = true;
            return response;
        }

        public async Task<Response<bool>> CheckCode(string searchText, int languageId)
        {
            Response<bool> response = new Response<bool>();
            var data = await _productRepository.CheckCode(searchText);

            response.Data = data;
            response.IsSuccess = true;

            return response;
        }

        public async Task<List<ElasticProductDto>> GetElasticData(int languageId)
        {
            var data = await _productRepository.GetElasticData();
            var response = Mapper.Map<List<ElasticProductDto>>(data);
            return response;
        }

        public async Task<Response<List<ProductDto>>> GetProduct(SearchProductDto productDto, int languageId)
        {
            var data = await _productRepository.GetProduct(productDto);
            return new Response<List<ProductDto>>()
            {
                Data = Mapper.Map<List<ProductDto>>(data),
                IsSuccess = true
            };

        }

        public async Task<Response<ProductDto>> GetProductDetail(string url, int languageId)
        {
            Response<ProductDto> response = new Response<ProductDto>();
            var data = await _productRepository.GetProductDetail(url, languageId);
            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<ProductDto>(data);
            }
            return response;
        }

        

        public async Task<Response<List<ProductDto>>> GetProductWithElkSearchResult(List<int> idList, OrderBy order, int languageId)
        {
            Response<List<ProductDto>> response = new Response<List<ProductDto>>();

            var data = await _productRepository.GetProductWithElkSearchResult(idList, order);

            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<ProductDto>>(data);
            }

            return response;
        }
    }


}