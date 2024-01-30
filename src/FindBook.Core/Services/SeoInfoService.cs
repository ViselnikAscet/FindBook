using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.SeoInfo;
using FindBook.Core.Models.Dto.Vehicle;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class SeoInfoService : BaseService<SeoInfo, SeoInfoDto>, ISeoInfoService
    {
        private protected readonly ISeoInfoRepository _seoInfoRepository;

        public SeoInfoService(
            ILogger<SeoInfoService> logger,
            IMapper mapper,
            ISeoInfoRepository repository,
            IValidator<SeoInfoDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _seoInfoRepository = repository;
        }


        public async Task<Response<SeoInfoDto>> GetSeoDataWithLink(string link, int languageId)
        {
            Response<SeoInfoDto> response = new Response<SeoInfoDto>();
            var data = await _seoInfoRepository.GetSeoDataWithLink(link);


            if (data != null)
            {
                response.Data = Mapper.Map<SeoInfoDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }


            return response;
        }

        public async Task<Response<SeoInfoDto>> GetSeoLinkWithVehicleData(int vehicleId, int languageId)
        {
            Response<SeoInfoDto> response = new Response<SeoInfoDto>();
            var data = await _seoInfoRepository.GetSeoLinkWithVehicleData(vehicleId);

            if (data != null)
            {
                response.Data = Mapper.Map<SeoInfoDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }


            return response;
        }

        public async Task<Response<SeoInfoDto>> GetSeoLinkWithVehicleData(SimpleVehicleDto vehicleDto, int languageId)
        {
            Response<SeoInfoDto> response = new Response<SeoInfoDto>();
            var data = await _seoInfoRepository.GetSeoLinkWithVehicleData(vehicleDto);


            if (data != null)
            {
                response.Data = Mapper.Map<SeoInfoDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
            }


            return response;
        }

        public async Task<Response<SeoInfoDto>> GetSeoWithCategoryId(int categoryId, int languageId)
        {
            Response<SeoInfoDto> response = new Response<SeoInfoDto>();


            var data = await _seoInfoRepository.GetSeoWithCategoryId(categoryId);

            if (data != null)
            {
                response.Data = Mapper.Map<SeoInfoDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7020", languageId));
            }


            return response;
        }
    }


}