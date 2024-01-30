using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.Warehouse;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class CampaignDetailService : BaseService<CampaignDetail, CampaignDetailDto>, ICampaignDetailService
    {
        private protected readonly ICampaignDetailRepository _campaignDetailRepository;

        public CampaignDetailService(
            ILogger<CampaignDetailService> logger, 
            IMapper mapper, 
            ICampaignDetailRepository repository,
            IValidator<CampaignDetailDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _campaignDetailRepository = repository;
        }

        public async Task<Response<List<CampaignDetailDto>>> GetCampaignDetail(int campaignId, int languageId)
        {
            Response<List<CampaignDetailDto>> response = new Response<List<CampaignDetailDto>>();

            var data = await _campaignDetailRepository.GetCampaignDetail(campaignId); 

            if(data != null){
                response.Data = Mapper.Map<List<CampaignDetailDto>>(data);
                response.IsSuccess = true;
            }   
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("" , languageId));
            }
            
            return response;
        }
    }


}