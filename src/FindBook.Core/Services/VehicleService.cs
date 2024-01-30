using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Vehicle;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VehicleService : BaseService<Vehicle, VehicleDto>, IVehicleService
    {
        private protected readonly IVehicleRepository _vehicleRepository;

        public VehicleService(
            ILogger<VehicleService> logger, 
            IMapper mapper, 
            IVehicleRepository repository,
            IValidator<VehicleDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _vehicleRepository = repository;
        }

        public async Task<Response<VehicleDto>> GetVehicleId(SimpleVehicleDto vehicleDto , int languageId)
        {
            Response<VehicleDto> response = new Response<VehicleDto>();

            var data = await _vehicleRepository.GetVehicleId(vehicleDto);

            if(data != null){
                response.Data = Mapper.Map<VehicleDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async  Task<Response<List<VehicleDto>>> GetVehicles(int languageId)
        {
            Response<List<VehicleDto>> response = new Response<List<VehicleDto>>();

            var data = await _vehicleRepository.GetVehicles();
            
            response.IsSuccess=true;
            response.Data = Mapper.Map<List<VehicleDto>>(data);
            return response;
        }

        public async Task<Response<VehicleDto>> GetVehicleWithId(int id , int languageId)
        {
            Response<VehicleDto> response = new Response<VehicleDto>();
            
            var data = await _vehicleRepository.GetVehicleWithId(id);

            if(data != null){
                response.Data = Mapper.Map<VehicleDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<Response<List<VehicleDto>>> GetVehicleWithParameters(SimpleVehicleDto simpleVehicleDto, int languageId)
        {
            Response<List<VehicleDto>> response = new Response<List<VehicleDto>>();

            var data = await _vehicleRepository.GetVehicleWithParameters(simpleVehicleDto,languageId);


            if(data != null){
                response.Data = Mapper.Map<List<VehicleDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.Errors.Add(await _errorService.GetByCode("7017",languageId));
                response.IsSuccess = false;
            }

            return response;
        }
    }


}