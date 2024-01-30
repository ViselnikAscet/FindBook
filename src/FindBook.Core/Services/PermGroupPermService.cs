using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.PermGroupPerm;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class PermGroupPermService : BaseService<PermGroupPerm, PermGroupPermDto>, IPermGroupPermService
    {
        private protected readonly IPermGroupPermRepository _permGroupPermRepository;

        public PermGroupPermService(
            ILogger<PermGroupPermService> logger,
            IMapper mapper,
            IPermGroupPermRepository repository,
            IValidator<PermGroupPermDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _permGroupPermRepository = repository;
        }

        public async Task<Response<List<PermGroupPermDto>>> GetListByPermGroupId(int permGroupId , int languageId)
        {
            var data = await _permGroupPermRepository.GetListByPermGroupId(permGroupId);

            return new Response<List<PermGroupPermDto>>(){Data = Mapper.Map<List<PermGroupPermDto>>(data),IsSuccess=true};
        }
    }


}