using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Currency;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class CurrencyService : BaseService<Currency, CurrencyDto>, ICurrencyService
    {
        private protected readonly ICurrencyRepository _currencyRepository;

        public CurrencyService(
            ILogger<CurrencyService> logger, 
            IMapper mapper, 
            ICurrencyRepository repository, 
            IValidator<CurrencyDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _currencyRepository = repository;
        }

        public async Task<Response<CurrencyDto>> GetCurrencyWithId(int currencyId , int languageId)
        {
            Response<CurrencyDto> response =  new Response<CurrencyDto>();
            var data = await _currencyRepository.GetCurrencyWithId(currencyId);
            if(data != null){
                response.Data = Mapper.Map<CurrencyDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess= false;
                response.Errors.Add(await _errorService.GetByCode("" , languageId));
            }
            return response;
        }
    }


}