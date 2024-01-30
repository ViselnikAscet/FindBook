using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.VehicleYear;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VehicleYearService : BaseService<VehicleYear, VehicleYearDto>, IVehicleYearService
    {
        private protected readonly IVehicleYearRepository _vehicleYearRepository;

        public VehicleYearService(
            ILogger<VehicleYearService> logger, 
            IMapper mapper, 
            IVehicleYearRepository repository,
            IValidator<VehicleYearDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _vehicleYearRepository = repository;
        }

        public async Task<Response<List<VehicleYearDto>>> GetVehiclesYears(int enginecodeId , int languageId)
        {
            Response<List<VehicleYearDto>> response = new Response<List<VehicleYearDto>>();
            var data = await _vehicleYearRepository.GetVehiclesModel(enginecodeId);

            if(data == null){
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<VehicleYearDto>>(data);
            }
            return response;
        }
    }


}