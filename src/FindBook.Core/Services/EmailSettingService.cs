using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Order;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class EmailSettingService : BaseService<EmailSetting, EmailSettingDto>, IEmailSettingService
    {
        private protected readonly IEmailSettingRepository _emailSettingRepository;


        public EmailSettingService(
            ILogger<EmailSettingService> logger,
            IMapper mapper,
            IEmailSettingRepository repository,
            IValidator<EmailSettingDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _emailSettingRepository = repository;
        }

        public async Task<Response<EmailSettingDto>> GetSettingAsync(int languageId)
        {
            Response<EmailSettingDto> response = new Response<EmailSettingDto>();
            var data = await _emailSettingRepository.GetSettingAsync();



            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("4001", languageId));
            }
            else
            {
                response.Data = Mapper.Map<EmailSettingDto>(data);
                response.IsSuccess = true;
            }

            return response;
        }
    }


}