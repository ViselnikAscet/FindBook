using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Customer;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Order;
using FindBook.Core.Models.Enum;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class EmailVerificationService : BaseService<EmailVerification, EmailVerificationDto>, IEmailVerificationService
    {
        private protected readonly IEmailVerificationRepository _emailVerificationRepository;

        public EmailVerificationService(
            ILogger<EmailVerificationService> logger,
            IMapper mapper,
            IEmailVerificationRepository repository,
            IValidator<EmailVerificationDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _emailVerificationRepository = repository;
        }

        public async Task<Response<int>> CheckKeys(string key1, string key2, string key3, EmailType type)
        {
            Response<int> response = new Response<int>();
            var check = await _emailVerificationRepository.GetByKeys(key1, key2, key3, EmailType.ForgetPassword);

            if(check != null){
                response.IsSuccess=true;
                response.Data = check.CustomerId;
            }
            else{
                response.IsSuccess=false;
                response.Data = -1;
            }

            return response;
        }
    }


}