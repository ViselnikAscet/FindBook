using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.FavoriteProduct;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class FavoriteProductService : BaseService<FavoriteProduct, FavoriteProductDto>, IFavoriteProductService
    {
        private protected readonly IFavoriteProductRepository _favoriteProductRepository;

        public FavoriteProductService(
            ILogger<FavoriteProductService> logger,
            IMapper mapper,
            IFavoriteProductRepository repository,
            IValidator<FavoriteProductDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _favoriteProductRepository = repository;
        }

        public async Task<Response<List<FavoriteProductDto>>> GetFavoriteProduct(int customerId, int languageId)
        {
            Response<List<FavoriteProductDto>>response = new Response<List<FavoriteProductDto>>();

            var data = await _favoriteProductRepository.GetFavoriteProduct(customerId,languageId);

            response.IsSuccess = true;
            response.Data = Mapper.Map<List<FavoriteProductDto>>(data);
            return response;

        }
    }


}