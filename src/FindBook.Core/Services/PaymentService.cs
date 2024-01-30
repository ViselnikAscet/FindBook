using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.Payment;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class PaymentService : BaseService<Payment, PaymentDto>, IPaymentService
    {
        private protected readonly IPaymentRepository _paymentRepository;

        public PaymentService(
            ILogger<PaymentService> logger, 
            IMapper mapper, 
            IPaymentRepository repository,
            IValidator<PaymentDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _paymentRepository = repository;
        }

        
    }


}