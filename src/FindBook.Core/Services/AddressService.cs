using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Address;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class AddressService : BaseService<Address, AddressDto>, IAddressService
    {
        private protected readonly IAddressRepository _addressRepository;

        public AddressService(
            ILogger<AddressService> logger,
            IMapper mapper,
            IAddressRepository repository,
            IValidator<AddressDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _addressRepository = repository;

        }


        public async Task<Response<List<AddressDto>>> GetAddressByCustomerId(int customerId , int languageId)
        {
           
            Response<List<AddressDto>> response = new Response<List<AddressDto>>();

            var data = await _addressRepository.GetAddressByCustomerId(customerId);

            if (data == null)
            {
                response.IsSuccess = false;
                // response.Errors.Add(await _errorService.GetByCode("4001", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<AddressDto>>(data);
            }
            
            return response;
        }
    }
}