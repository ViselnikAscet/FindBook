using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.VirtualPos;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class VirtualPosService : BaseService<VirtualPos, VirtualPosDto>, IVirtualPosService
    {
        private protected readonly IVirtualPosRepository _virtualPosRepository;

        public VirtualPosService(
            ILogger<VirtualPosService> logger, 
            IMapper mapper, 
            IVirtualPosRepository repository,
            IValidator<VirtualPosDto> validator,
            IErrorService errorService) : base(logger, mapper, repository,validator,errorService)
        {
            _virtualPosRepository = repository;
        }

        
    }


}