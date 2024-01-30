using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Perm;
using FindBook.Core.Models.Dto.PermGroup;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class PermGroupService : BaseService<PermGroup, PermGroupDto>, IPermGroupService
    {
        private protected readonly IPermGroupRepository _permGroupRepository;
        private protected readonly IPermRepository _permRepository;



        public PermGroupService(
            ILogger<PermGroupService> logger,
            IMapper mapper,
            IPermGroupRepository repository,
            IPermRepository permRepository,
            IValidator<PermGroupDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _permGroupRepository = repository;
            _permRepository =permRepository;
        }

        public async Task<Response<List<PermDto>>> GetPerms(int permGroupId , int languageId)
        {
            Response<List<PermDto>> result = new Response<List<PermDto>>();

            result.Data = Mapper.Map<List<PermDto>>(await _permRepository.GetPerms(permGroupId));

            return result;
        }
    }


}