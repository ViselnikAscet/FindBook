using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Supplier;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class SupplierService : BaseService<Supplier, SupplierDto>, ISupplierService
    {
        private protected readonly ISupplierRepository _supplierRepository;

        public SupplierService(
            ILogger<SupplierService> logger,
            IMapper mapper,
            ISupplierRepository repository,
            IValidator<SupplierDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _supplierRepository = repository;
        }

        public async Task<Response<SupplierDto>> GetSupplierDetail(int supplierId, int languageId)
        {
            Response<SupplierDto> response = new Response<SupplierDto>();

            var data = await _supplierRepository.GetSupplierDetail(supplierId);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7021", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<SupplierDto>(data);
            }
            return response;

        }

        public async Task<Response<List<SupplierDto>>> GetSuppliers(string suppliersName, int languageId)
        {
            Response<List<SupplierDto>> response = new Response<List<SupplierDto>>();

            var data = await _supplierRepository.GetSuppliers(suppliersName);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7021", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<SupplierDto>>(data);
            }
            return response;
        }
    }


}