using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ShipmentCompanyParameter;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ShipmentCompanyParameterService : BaseService<ShipmentCompanyParameter, ShipmentCompanyParameterDto>, IShipmentCompanyParameterService
    {
        private protected readonly IShipmentCompanyParameterRepository _shipmentCompanyParameterRepository;

        public ShipmentCompanyParameterService(
            ILogger<ShipmentCompanyParameterService> logger, 
            IMapper mapper, 
            IShipmentCompanyParameterRepository repository,
            IValidator<ShipmentCompanyParameterDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _shipmentCompanyParameterRepository = repository;
        }

        public async Task<Response<ShipmentCompanyParameterDto>> CheckShipmentCompanyParameter(int id, int languageId)
        {
            Response<ShipmentCompanyParameterDto> response = new Response<ShipmentCompanyParameterDto>();

            var data =await  _shipmentCompanyParameterRepository.CheckShipmentCompanyParameter(id);
            
            if(data != null)
            {
                response.Data = Mapper.Map<ShipmentCompanyParameterDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("" , languageId));
            }
            return response;
        }
    }


}