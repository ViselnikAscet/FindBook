using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Basket;
using FindBook.Core.Models.Dto.MenuItem;
using FindBook.Core.Models.Dto.Oem;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class MenuItemService : BaseService<MenuItem, MenuItemDto>, IMenuItemService
    {
        private protected readonly IMenuItemRepository _menuItemRepository;

        public MenuItemService(
            ILogger<MenuItemService> logger,
            IMapper mapper,
            IMenuItemRepository repository,
            IValidator<MenuItemDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _menuItemRepository = repository;
        }

        public async Task<Response<List<MenuItemDto>>> GetAllMenuItems(int languageId)
        {
            Response<List<MenuItemDto>> response = new Response<List<MenuItemDto>>();

            var data = await _menuItemRepository.GetAllMenuItems(languageId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<MenuItemDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8007", languageId));
            }

            return response;
        }



        public async Task<Response<List<MenuItemDto>>> GetHeaderMenuItems(int languageId)
        {
            Response<List<MenuItemDto>> response = new Response<List<MenuItemDto>>();

            var data = await _menuItemRepository.GetHeaderMenuItems(languageId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<MenuItemDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("8007", languageId));
            }

            return response;
        }

        public async Task<Response<MenuItemDto>> GetMenuWithId(int id, int languageId)
        {
            Response<MenuItemDto> response = new Response<MenuItemDto>();

            var data = await _menuItemRepository.GetMenuWithId(id);

            if (data != null)
            {
                response.Data = Mapper.Map<MenuItemDto>(data);
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