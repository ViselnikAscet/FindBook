using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Oem;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class OemService : BaseService<Oem, OemDto>, IOemService
    {
        private protected readonly IOemRepository _oemRepository;

        public OemService(
            ILogger<OemService> logger,
            IMapper mapper,
            IOemRepository repository,
            IValidator<OemDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _oemRepository = repository;
        }

        public async Task<Response<bool>> CheckOems(string searchText, int languageId)
        {
            Response<bool> response = new Response<bool>();
            var data = await _oemRepository.CheckOem(searchText);
            
                response.Data = data;
                response.IsSuccess = true;
            
            
            return response;
        }
    }


}