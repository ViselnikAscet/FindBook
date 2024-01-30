using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Helpers;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Resource;
using FindBook.Core.Models.Dto.Setting;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
namespace FindBook.Core.Services
{

    public class ResourceService : BaseService<Resource, ResourceDto>, IResourceService
    {
        private protected readonly IResourceRepository _resourceRepository;
        private readonly IDistributedCache _distributedCache;

        private readonly ILanguageService _languageService;

        public ResourceService(
            ILogger<ResourceService> logger,
            IMapper mapper,
            IResourceRepository repository,
            IValidator<ResourceDto> validator,
            IErrorService errorService,
            ILanguageService languageService,
            IDistributedCache distributedCache) : base(logger, mapper, repository, validator, errorService)
        {
            _resourceRepository = repository;
            _distributedCache = distributedCache;
            _languageService = languageService;
        }

        public async Task<Response<string>> GetByKey(string key, int languageId)
        {

            Response<string> result = new Response<string>();

            string value;

            value = await _distributedCache.GetStringAsync("b2c_resource_" + languageId.ToString() + "_" + key);

            if (value == null)
            {
                value = await _resourceRepository.GetByKey(key, languageId);
                if (value == null)
                {
                    result.IsSuccess = false;
                    result.Errors.Add(await _errorService.GetByCode("2001", languageId));
                }
                else
                {
                    await _distributedCache.SetStringAsync("b2c_resource_" + languageId.ToString() + "_" + key, value);
                }
            }
            result.Data = value;
            return result;
        }
        public async Task<Response<string>> GetByKey(string key, string value, SettingDto setting)
        {
            Response<string> result = new Response<string>();

            string _value;

            _value = await _distributedCache.GetStringAsync("b2c_resource_" + setting.LanguageId.ToString() + "_" + key);

            if (_value == null)
            {
                _value = await _resourceRepository.GetByKey(key, setting.LanguageId);
                if (_value == null)
                {
                    _value = value;
                    if (setting.Language.IsDefault)
                    {
                        ResourceDto resource = new ResourceDto();

                        resource.Key = key;
                        resource.Value = value;
                        resource.LanguageId = setting.LanguageId;
                        resource.IsActive = true;
                        await AddAsync(resource, resource.LanguageId);
                    }
                    else
                    {
                        var defaultLang = await _languageService.GetDefault();

                        if (defaultLang.IsSuccess)
                        {
                            ResourceDto resource = new ResourceDto();

                            resource.Key = key;
                            resource.Value = value;
                            resource.LanguageId = defaultLang.Data.Id;
                            await AddAsync(resource, resource.LanguageId);

                        }

                    }

                    // result.IsSuccess =false;
                    // result.Errors.Add(await _errorService.GetByCode("2001",setting.LanguageId));
                }
                await _distributedCache.SetStringAsync("b2c_resource_" + setting.LanguageId.ToString() + "_" + key, value);

            }
            result.Data = _value;
            return result;
        }
    }


}