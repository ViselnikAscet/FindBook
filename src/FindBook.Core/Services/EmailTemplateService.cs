using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Order;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class EmailTemplateService : BaseService<EmailTemplate, EmailTemplateDto>, IEmailTemplateService
    {
        private protected readonly IEmailTemplateRepository _emailTemplateRepository;


        public EmailTemplateService(
            ILogger<EmailTemplateService> logger,
            IMapper mapper,
            IEmailTemplateRepository repository,
            IValidator<EmailTemplateDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _emailTemplateRepository = repository;
        }


        public async Task<Response<EmailTemplateDto>> GetTemplate(string key, int languageId)
        {
            Response<EmailTemplateDto> response = new Response<EmailTemplateDto>();
            var data = await _emailTemplateRepository.GetTemplate(key,languageId);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("4002", languageId));
            }
            else
            {
                response.Data = Mapper.Map<EmailTemplateDto>(data);
                response.IsSuccess = true;
            }
    
            return response;
        }
    }


}