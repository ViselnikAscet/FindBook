using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.CustomerCar;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class CustomerCarService : BaseService<CustomerCar, CustomerCarDto>, ICustomerCarService
    {
        private protected readonly ICustomerCarRepository _customerCarRepository;

        public CustomerCarService(
            ILogger<CustomerCarService> logger, 
            IMapper mapper, 
            ICustomerCarRepository repository, 
            IValidator<CustomerCarDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _customerCarRepository = repository;
        }

        public async Task<Response<List<CustomerCarDto>>> GetMyGarage(int customerId, int languageId)
        {
            Response<List<CustomerCarDto>> response = new Response<List<CustomerCarDto>>();

            var result = await _customerCarRepository.GetMyGarage(customerId);

            if(result != null){
                response.Data = Mapper.Map<List<CustomerCarDto>>(result);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7013",languageId));
            }

            return response;
        }
    }


}