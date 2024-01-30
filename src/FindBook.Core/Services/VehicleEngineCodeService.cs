using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.VehicleEngineCode;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VehicleEngineCodeService : BaseService<VehicleEngineCode, VehicleEngineCodeDto>, IVehicleEngineCodeService
    {
        private protected readonly IVehicleEngineCodeRepository _vehicleEngineCodeRepository;

        public VehicleEngineCodeService(
            ILogger<VehicleEngineCodeService> logger, 
            IMapper mapper, 
            IVehicleEngineCodeRepository repository,
            IValidator<VehicleEngineCodeDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _vehicleEngineCodeRepository = repository;
        }

        public async Task<Response<List<VehicleEngineCodeDto>>> GetVehiclesEngineCodes(int modelId , int languageId)
        {
            Response<List<VehicleEngineCodeDto>> response = new Response<List<VehicleEngineCodeDto>>();
            
            var data = await _vehicleEngineCodeRepository.GetVehiclesEngineCodes(modelId);

            if(data == null){
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess= true;
                response.Data = Mapper.Map<List<VehicleEngineCodeDto>>(data);
            }


            return response;
        }
    }


}