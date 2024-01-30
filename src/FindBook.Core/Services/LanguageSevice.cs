using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class LanguageService : BaseService<Language, LanguageDto>, ILanguageService
    {
        private protected readonly ILanguageRepository _languageRepository;

        public LanguageService(
            ILogger<LanguageService> logger,
            IMapper mapper,
            ILanguageRepository repository,
            IValidator<LanguageDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _languageRepository = repository;
        }

        public async Task<Response<List<LanguageDto>>> GetAllLanguage(int languageId)
        {
            Response<List<LanguageDto>> response = new Response<List<LanguageDto>>();

            var data = await _languageRepository.GetAllLanguage();

            if (data != null)
            {
                response.Data = Mapper.Map<List<LanguageDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("2001" ,languageId));
            }

            return response;
        }

        public async Task<Response<LanguageDto>> GetDefault()
        {
            Response<LanguageDto> response = new Response<LanguageDto>();

            var data = _languageRepository.GetDefault();

            if (data != null)
            {
                response.Data = Mapper.Map<LanguageDto>(data);
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(new SimpleErrorDto() { Code = "-1", Message = "Varsayılan dil bulunmadı" });
            }

            return response;
        }
    }


}