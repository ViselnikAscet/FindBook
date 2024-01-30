using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.ClientSession;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ClientSessionService : BaseService<ClientSession, ClientSessionDto>, IClientSessionService
    {
        private protected readonly IClientSessionRepository _clientSessionRepository;

        public ClientSessionService(
            ILogger<ClientSessionService> logger,
            IMapper mapper,
            IClientSessionRepository repository,
            IValidator<ClientSessionDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _clientSessionRepository = repository;
        }

        public async Task<Response<ClientSessionDto>> GetForRefresh(int clientId, string lastToken , int languageId)
        {
            var data = await _clientSessionRepository.GetForRefresh(clientId,lastToken);


            if (data!=null)
            {
                return new Response<ClientSessionDto>(){IsSuccess = true, Data = Mapper.Map<ClientSessionDto>(data)};
            }

            return new Response<ClientSessionDto>(){IsSuccess = false};

        }
    }


}