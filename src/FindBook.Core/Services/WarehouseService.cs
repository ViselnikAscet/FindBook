using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.Warehouse;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class WarehouseService : BaseService<Warehouse, WarehouseDto>, IWarehouseService
    {
        private protected readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(
            ILogger<WarehouseService> logger, 
            IMapper mapper, 
            IWarehouseRepository repository,
            IValidator<WarehouseDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _warehouseRepository = repository;
        }

        
    }


}