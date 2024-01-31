using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using FindBook.Core.Interfaces.Repositories.Base;

namespace FindBook.Core.Services
{

    public class CampaignService : BaseService<Campaign, CampaignDto>, ICampaignService
    {
        private protected readonly ICampaignRepository _campaignRepository;

        public CampaignService(ILogger<BaseService<Campaign, CampaignDto>> logger, IMapper mapper, IBaseRepository<Campaign> repository, IValidator<CampaignDto> validator, IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
        }

        public async Task<Response<List<CampaignDto>>> GetAllCampaigns(int languageId)
        {
            Response<List<CampaignDto>> response = new Response<List<CampaignDto>>();
            
            var data = await _campaignRepository.GetAllCampaigns(languageId);

            if(data != null){
                response.Data = Mapper.Map<List<CampaignDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add( await _errorService.GetByCode( "" , languageId));
            }

            return  response;
        }
    }

  
}