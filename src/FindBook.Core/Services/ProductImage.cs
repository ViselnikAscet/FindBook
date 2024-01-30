using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ProductImage;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ProductImageService : BaseService<ProductImage, ProductImageDto>, IProductImageService
    {
        private protected readonly IProductImageRepository _productImageRepository;

        public ProductImageService(
            ILogger<ProductImageService> logger,
            IMapper mapper,
            IProductImageRepository repository,
            IValidator<ProductImageDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productImageRepository = repository;
        }
    }


}