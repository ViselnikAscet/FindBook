using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Basket;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class BasketHeaderService : BaseService<BasketHeader, BasketHeaderDto>, IBasketHeaderService
    {
        private protected readonly IBasketHeaderRepository _basketHeaderRepository;

        public BasketHeaderService(
            ILogger<BasketHeaderService> logger,
            IMapper mapper,
            IBasketHeaderRepository repository,
            IValidator<BasketHeaderDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _basketHeaderRepository = repository;

        }

    }


}