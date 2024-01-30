using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class LanguageBasedInfoService : BaseService<LanguageBasedInfo, LanguageBasedInfoDto>, ILanguageBasedInfoService
    {
        private protected readonly ILanguageBasedInfoRepository _languageBasedInfoRepository;

        public LanguageBasedInfoService(
            ILogger<LanguageBasedInfoService> logger,
            IMapper mapper,
            ILanguageBasedInfoRepository repository,
            IValidator<LanguageBasedInfoDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)

        {
            _languageBasedInfoRepository = repository;
        }

        public  async Task<Response<List<LanguageBasedInfoDto>>> GetCampaignLanguageBasedInfos(int campaignId, int languageId)
        {
            Response<List<LanguageBasedInfoDto>> response = new Response<List<LanguageBasedInfoDto>>();

            var data = await _languageBasedInfoRepository.GetCampaignLanguageBasedInfos(campaignId);

            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<LanguageBasedInfoDto>>(data);
            }

            return response;
        }

        public async Task<Response<List<LanguageBasedInfoDto>>> GetMenuItemAllLangBasedInfos(int menuItemId, int languageId)
        {
            Response<List<LanguageBasedInfoDto>> response = new Response<List<LanguageBasedInfoDto>>();
            var data = await _languageBasedInfoRepository.GetMenuItemAllLangBasedInfos(menuItemId);

            if (data == null)
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("", languageId));
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<LanguageBasedInfoDto>>(data);
            }

            return response;
        }

        public async Task<Response<LanguageBasedInfoDto>> GetProductInfo(int productId, int languageId)
        {
            Response<LanguageBasedInfoDto> response = new Response<LanguageBasedInfoDto>();

            var data = await _languageBasedInfoRepository.GetProductInfo(productId);

            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<LanguageBasedInfoDto>(data);
            }

            return response;
        }

        public async Task<Response<List<LanguageBasedInfoDto>>> GetVehicleAllLangBasedInfos(int vehicleId, int languageId)
        {
            Response<List<LanguageBasedInfoDto>> response = new Response<List<LanguageBasedInfoDto>>();

            var data = await _languageBasedInfoRepository.GetVehicleAllLangBasedInfos(vehicleId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<LanguageBasedInfoDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7018", languageId));
            }

            return response;
        }

        public async Task<Response<LanguageBasedInfoDto>> GetVehicleInfo(int vehicleId, int languageId)
        {
            Response<LanguageBasedInfoDto> response = new Response<LanguageBasedInfoDto>();

            var data = await _languageBasedInfoRepository.GetVehicleInfo(vehicleId, languageId);


            if (data != null)
            {
                response.Data = Mapper.Map<LanguageBasedInfoDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7018", languageId));
            }

            return response;
        }
    }


}