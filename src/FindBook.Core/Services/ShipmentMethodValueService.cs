using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ShipmentMethodValue;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ShipmentMethodValueService : BaseService<ShipmentMethodValue, ShipmentMethodValueDto>, IShipmentMethodValueService
    {
        private protected readonly IShipmentMethodValueRepository _shipmentMethodValueRepository;

        public ShipmentMethodValueService(
            ILogger<ShipmentMethodValueService> logger,
            IMapper mapper,
            IShipmentMethodValueRepository repository,
            IValidator<ShipmentMethodValueDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _shipmentMethodValueRepository = repository;
        }

        public async Task<Response<ShipmentMethodValueDto>> GetShipmentMethodValueWithMethodId(int shipmentMethodId, int languageId)
        {
            Response<ShipmentMethodValueDto> response = new Response<ShipmentMethodValueDto>();

            var data = await _shipmentMethodValueRepository.GetShipmentMethodValueWithMethodId(shipmentMethodId);

            if (data != null)
            {
                response.Data = Mapper.Map<ShipmentMethodValueDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8009", languageId));
            }

            return response;
        }
    }


}