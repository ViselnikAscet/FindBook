using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Perm;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class PermService : BaseService<Perm, PermDto>, IPermService
    {
        private protected readonly IPermRepository _permRepository;

        public PermService(
            ILogger<PermService> logger,
            IMapper mapper,
            IPermRepository repository,
            IValidator<PermDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _permRepository = repository;
        }

        public async Task<Response<List<PermDto>>> GetMenuByPermGroupId(int permGroupId , int languageId)
        {
            var data = await _permRepository.GetMenuByPermGroupId(permGroupId);

            return new Response<List<PermDto>>(){Data = Mapper.Map<List<PermDto>>(data),IsSuccess=true};
        }

        public async Task<Response<List<PermDto>>> GetNotAllowEveryTime(int languageId)
        {  
             var data = await _permRepository.GetNotAllowEveryTime();

             return new Response<List<PermDto>>(){Data = Mapper.Map<List<PermDto>>(data),IsSuccess=true};
        }
    }


}