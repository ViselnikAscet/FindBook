using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ShipmentMethod;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ShipmentMethodService : BaseService<ShipmentMethod, ShipmentMethodDto>, IShipmentMethodService
    {
        private protected readonly IShipmentMethodRepository _shipmentMethodRepository;

        public ShipmentMethodService(
            ILogger<ShipmentMethodService> logger, 
            IMapper mapper, 
            IShipmentMethodRepository repository,
            IValidator<ShipmentMethodDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _shipmentMethodRepository = repository;
        }

        public async Task<Response<List<ShipmentMethodDto>>> GetAllShipmentMethod(int id, int languageId)
        {
            Response<List<ShipmentMethodDto>> response = new Response<List<ShipmentMethodDto>>();

            var data  = await _shipmentMethodRepository.GetAllShipmentMethod(id ,languageId);

            if(data != null)
            {   
                response.Data = Mapper.Map<List<ShipmentMethodDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8009" , languageId));
            }

            return response;
        }
    }


}