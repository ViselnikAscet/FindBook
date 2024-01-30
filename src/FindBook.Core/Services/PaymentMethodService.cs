using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.PaymentMethod;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class PaymentMethodService : BaseService<PaymentMethod, PaymentMethodDto>, IPaymentMethodService
    {
        private protected readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(
            ILogger<PaymentMethodService> logger,
            IMapper mapper,
            IPaymentMethodRepository repository,
            IValidator<PaymentMethodDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _paymentMethodRepository = repository;
        }

        public async Task<Response<List<PaymentMethodDto>>> GetAllPaymentMethods(int languageId)
        {
            Response<List<PaymentMethodDto>> response = new Response<List<PaymentMethodDto>>();

            var data = await _paymentMethodRepository.GetAll();

            if(data != null){
                response.Data = Mapper.Map<List<PaymentMethodDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7016",languageId));
            }


            return response;
        }
    }


}