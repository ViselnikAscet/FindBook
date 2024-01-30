using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Token;
using FindBook.Core.Models.Dto.Token;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class TokenService : BaseService<Token, TokenDto>, ITokenService
    {
        private protected readonly ITokenRepository _tokenRepository;

        public TokenService(
            ILogger<TokenService> logger, 
            IMapper mapper, 
            ITokenRepository repository,
            IValidator<TokenDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _tokenRepository = repository;
        }

        public async Task<Response<TokenDto>> CheckModuleToken(int moduleCode, int languageId)
        {
           Response<TokenDto> response = new Response<TokenDto>();

            var check = await _tokenRepository.CheckModuleToken(moduleCode);


            if(check != null){
                response.Data = Mapper.Map<TokenDto>(check);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8001",languageId));
            }
        
           return response;
        }
    }


}