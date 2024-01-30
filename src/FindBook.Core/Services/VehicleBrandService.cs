using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.VehicleBrand;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VehicleBrandService : BaseService<VehicleBrand, VehicleBrandDto>, IVehicleBrandService
    {
        private protected readonly IVehicleBrandRepository _vehicleBrandRepository;

        public VehicleBrandService(
            ILogger<VehicleBrandService> logger,
            IMapper mapper,
            IVehicleBrandRepository repository,
            IValidator<VehicleBrandDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _vehicleBrandRepository = repository;
        }

        public async Task<Response<List<VehicleBrandDto>>> GetVehiclesBrand(int languageId)
        {
            Response<List<VehicleBrandDto>> response = new Response<List<VehicleBrandDto>>();
            var data = await _vehicleBrandRepository.GetVehiclesBrand();
            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<VehicleBrandDto>>(data);
            }
            return response;
        }

        public async Task<Response<VehicleBrandDto>> GetVehiclesBrandWithId(int id, int languageId)
        {
            Response<VehicleBrandDto> response = new Response<VehicleBrandDto>();
            var data = await _vehicleBrandRepository.GetVehiclesBrandWithId(id);
            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<VehicleBrandDto>(data);
            }
            return response;
        }
    }
}