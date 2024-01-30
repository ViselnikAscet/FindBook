using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Services.Bases;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ErrorService : IErrorService
    {
        private protected readonly IErrorRepository _errorRepository;
        private protected readonly IMapper _mapper;
        private protected readonly ILogger<ErrorService> _logger;


        public ErrorService(
            ILogger<ErrorService> logger, 
            IMapper mapper, 
            IErrorRepository repository)
        {
            _errorRepository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SimpleErrorDto> GetByCode(string code, int languageId)
        {
            return _mapper.Map<SimpleErrorDto>(await _errorRepository.GetByCode(code,languageId));
        }
    }


}