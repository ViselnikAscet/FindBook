using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ShipmentCompany;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ShipmentCompanyService : BaseService<ShipmentCompany, ShipmentCompanyDto>, IShipmentCompanyService
    {
        private protected readonly IShipmentCompanyRepository _shipmentCompanyRepository;

        public ShipmentCompanyService(
            ILogger<ShipmentCompanyService> logger,
            IMapper mapper,
            IShipmentCompanyRepository repository,
            IValidator<ShipmentCompanyDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _shipmentCompanyRepository = repository;
        }

        public async Task<Response<List<ShipmentCompanyDto>>> GetAllShipment(int languageId)
        {
            Response<List<ShipmentCompanyDto>> response = new Response<List<ShipmentCompanyDto>>();

            var data = await _shipmentCompanyRepository.GetAllShipment();

            if (data != null)
            {
                response.Data = Mapper.Map<List<ShipmentCompanyDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8008", languageId));
            }


            return response;
        }

        public async Task<Response<ShipmentCompanyDto>> GetShipmentWithId(int id, int languageId)
        {
            Response<ShipmentCompanyDto> response = new Response<ShipmentCompanyDto>();

            var data = await _shipmentCompanyRepository.GetShipmentWithId(id);

            if (data != null)
            {
                response.Data = Mapper.Map<ShipmentCompanyDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8008", languageId));
            }


            return response;
        }
    }


}