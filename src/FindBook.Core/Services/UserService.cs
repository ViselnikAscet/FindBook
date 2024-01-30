using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class UserService : BaseService<User, UserDto>, IUserService
    {
        private protected readonly IUserRepository _userRepository;
        private protected readonly IValidator<UserLoginDto> _userLoginValidator;


        public UserService(
            ILogger<UserService> logger,
            IMapper mapper,
            IUserRepository repository,
            IValidator<UserDto> validator,
            IValidator<UserLoginDto> userLoginValidator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _userRepository = repository;
            _userLoginValidator = userLoginValidator;
        }

        public async Task<Response<UserDto>> GetUserLogin(UserLoginDto login, int languageId)
        {
            Response<UserDto> result = new Response<UserDto>();
            var validResult = await _userLoginValidator.ValidateAsync(login);
            if (!validResult.IsValid)
            {
                result.IsSuccess = false;
                foreach (var error in validResult.Errors)
                {
                    result.Errors.Add(await _errorService.GetByCode(error.ErrorCode, languageId));
                }
            }
            else
            {
                var userResult = await _userRepository.GetForLogin(login);
                if (userResult == null)
                {
                    result.IsSuccess = false;
                    result.Errors.Add(await _errorService.GetByCode("3009", languageId));
                }
                else
                {
                    result.IsSuccess = true;
                    result.Data = Mapper.Map<UserDto>(userResult);
                }
            }
            return result;
        }
    }
}