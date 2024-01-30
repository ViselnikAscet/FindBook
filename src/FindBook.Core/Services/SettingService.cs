using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Services.Bases;
using FindBook.Core.Models.Dto.Setting;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Error;

namespace FindBook.Core.Services
{

    public class SettingService : BaseService<Setting, SettingDto>, ISettingService
    {
        private protected readonly ISettingRepository _settingRepository;
        private protected readonly ILanguageService _languageService;

        public SettingService(
            ILogger<SettingService> logger,
            IMapper mapper,
            ISettingRepository repository,
            IValidator<SettingDto> validator,
            IErrorService errorService,
            ILanguageService languageService) : base(logger, mapper, repository, validator, errorService)
        {
            _settingRepository = repository;
            _languageService = languageService;
        }

        public async Task<Response<CheckSettingDto>> CheckRequiredSetting()
        {
            Response<CheckSettingDto> response = new Response<CheckSettingDto>();
            
            var setting = await _settingRepository.GetDefault();

            var data = await _settingRepository.CheckRequiredSetting(setting.Id);


            response.Data = Mapper.Map<CheckSettingDto>(data);
            response.IsSuccess = true;

            return response;
        }

        public async Task<Response<SettingDto>> GetDefault()
        {
            Response<SettingDto> response = new Response<SettingDto>();

            var data = await _settingRepository.GetDefault();

            if (data != null)
            {
                response.Data = Mapper.Map<SettingDto>(data);
                return response;
            }

            response.IsSuccess = false;

            var languageData = await _languageService.GetDefault();

            if (languageData.IsSuccess)
            {
                response.Errors.Add(await _errorService.GetByCode("1001", languageData.Data.Id));
            }
            else
            {
                foreach (var error in languageData.Errors)
                {
                    response.Errors.Add(error);
                }
            }

            return response;

        }

        public async Task<Response<SettingDto>> GetSettingWithId(int id, int languageId)
        {
            Response<SettingDto> response = new Response<SettingDto>();
            
            var data = await _settingRepository.GetSettingWithId(id);

            if(data != null){
                response.Data = Mapper.Map<SettingDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false ; 
                response.Errors.Add(await _errorService.GetByCode("8006", languageId));
            }

            return response;
        }

        public async Task<Response<SettingDto>> GetWithLanguage(int id)
        {
            var data = await _settingRepository.GetWithLanguage(id);

            return new Response<SettingDto>(){
                Data = Mapper.Map<SettingDto>(data),
                IsSuccess=true
            };

        }
    }


}