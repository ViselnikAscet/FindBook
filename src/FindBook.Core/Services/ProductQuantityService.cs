using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ProductQuantity;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ProductQuantityService : BaseService<ProductQuantity, ProductQuantityDto>, IProductQuantityService
    {
        private protected readonly IProductQuantityRepository _productQuantityRepository;

        public ProductQuantityService(
            ILogger<ProductQuantityService> logger,
            IMapper mapper,
            IProductQuantityRepository repository,
            IValidator<ProductQuantityDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _productQuantityRepository = repository;
        }
    }


}