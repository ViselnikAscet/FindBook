using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Basket;
using FindBook.Core.Models.Dto.MenuSection;
using FindBook.Core.Models.Dto.Oem;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class MenuSectionService : BaseService<MenuSection, MenuSectionDto>, IMenuSectionService
    {
        private protected readonly IMenuSectionRepository _menuSectionRepository;

        public MenuSectionService(
            ILogger<MenuSectionService> logger,
            IMapper mapper,
            IMenuSectionRepository repository,
            IValidator<MenuSectionDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _menuSectionRepository = repository;
        }

        public async Task<Response<List<MenuSectionDto>>> GetFooterMenuItems(int languageId)
        {
            Response<List<MenuSectionDto>> response = new Response<List<MenuSectionDto>>();

            var data = await _menuSectionRepository.GetFooterMenuItems(languageId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<MenuSectionDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8007", languageId));
            }

            return response;
        }
    }


}