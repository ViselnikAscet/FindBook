using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.VehicleModel;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VehicleModelService : BaseService<VehicleModel, VehicleModelDto>, IVehicleModelService
    {
        private protected readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(
            ILogger<VehicleModelService> logger, 
            IMapper mapper, 
            IVehicleModelRepository repository,
            IValidator<VehicleModelDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _vehicleModelRepository = repository;
        }

        public async Task<Response<List<VehicleModelDto>>> GetVehiclesModel(int brandId , int languageId)
        {
            Response<List<VehicleModelDto>> response = new Response<List<VehicleModelDto>>();

            var data = await _vehicleModelRepository.GetVehiclesModel(brandId);

            if(data == null){
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<VehicleModelDto>>(data);
            }

            return response;
        }
    }


}