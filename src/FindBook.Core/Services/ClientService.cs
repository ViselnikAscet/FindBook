using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Authentication;
using FindBook.Core.Models.Dto.Client;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class ClientService : BaseService<Client, ClientDto>, IClientService
    {
        private protected readonly IClientRepository _clientRepository;

        public ClientService(
            ILogger<ClientService> logger,
            IMapper mapper,
            IClientRepository repository,
            IValidator<ClientDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _clientRepository = repository;
        }

        public async Task<Response<ClientDto>> GetForLogin(ClientLogin login , int languageId)
        {
            var data = await _clientRepository.GetForLogin(login);
    
            if (data!=null)
            {
                return new Response<ClientDto>(){
                    IsSuccess = true,
                    Data = Mapper.Map<ClientDto>(data)

                };
            }
            
            return new Response<ClientDto>(){
                    IsSuccess = false
            };
        }
    }


}