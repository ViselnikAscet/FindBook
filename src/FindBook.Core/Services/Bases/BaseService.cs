using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FindBook.Core.Entity.Base;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Error;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Interfaces.Repositories;

namespace FindBook.Core.Services.Bases
{

    public class BaseService<T, TDto> : IBaseService<TDto> where T : BaseEntity where TDto : BaseEntityDto
    {
        private protected readonly ILogger Logger;

        private protected readonly IMapper Mapper;

        private protected readonly IBaseRepository<T> Repository;
        private protected readonly IValidator Validator;
        private protected readonly IErrorService _errorService;
        private ICampaignDetailRepository repository;
        private IErrorService errorService;

        public BaseService(ILogger<BaseService<T, TDto>> logger, IMapper mapper, IBaseRepository<T> repository, IValidator<TDto> validator, IErrorService errorService)
        {
            Logger = logger;
            Mapper = mapper;
            Repository = repository;
            Validator = validator;
            _errorService = errorService;
        }

        public BaseService(ILogger<CampaignDetailService> logger, IMapper mapper, ICampaignDetailRepository repository, IValidator<CampaignDetailDto> validator, IErrorService errorService)
        {
            Logger = logger;
            Mapper = mapper;
            this.repository = repository;
            Validator = validator;
            this.errorService = errorService;
        }

        public virtual async Task<Response<TDto>> AddAsync(TDto item, int languageId)
        {

            ValidationResult validationResult = await Validator.ValidateAsync(new ValidationContext<TDto>(item));


            if (!validationResult.IsValid)
            {
                List<SimpleErrorDto> errors = new List<SimpleErrorDto>();
                foreach (string errorCode in validationResult.Errors.Select(x => x.ErrorCode).ToList())
                {
                    errors.Add(await _errorService.GetByCode(errorCode, languageId));
                }

                return new Response<TDto>{
                    IsSuccess=false,
                    Errors = errors,
                    Data=item
                };

            }

            T entity = Mapper.Map<T>(item);
            bool result = await Repository.AddAsync(entity);

            if (result)
            {
                return new Response<TDto>
                {
                    Data = Mapper.Map<TDto>(entity),
                    IsSuccess = true
                };
            }
            return new Response<TDto>
            {
                Data = item,
                IsSuccess = false
            };
        }

        public virtual async Task<Response<int>> CountAsync()
        {
            return new Response<int>
            {
                Data = await Repository.CountAsync(),
                IsSuccess = true,
            };
        }

        public virtual async Task<Response<TDto>> GetAsync(int id, int languageId, bool isTracking = false)
        {
            T item = await Repository.GetAsync(id,isTracking);

            if (item != null)
            {
                return new Response<TDto>
                {
                    Data = Mapper.Map<TDto>(item),
                    IsSuccess = true,
                };
            }
            return new Response<TDto>
            {
                IsSuccess = false
            };
        }

        public virtual async Task<Response<IReadOnlyList<TDto>>> GetAsync(int languageId, bool isTracking = true,bool isActiveFilter = false, bool isActive = true)
        {
            IReadOnlyList<T> items = await Repository.GetListAsync(isActiveFilter, isActive,isTracking);

            if (items != null)
            {
                return new Response<IReadOnlyList<TDto>>
                {
                    Data = Mapper.Map<IReadOnlyList<TDto>>(items),
                    IsSuccess = true,
                };
            }
            return new Response<IReadOnlyList<TDto>>
            {
                IsSuccess = false,
            };
        }
   
    //  public Task<Response<TDto>> GetAsync(int id, string queryFilter = null, string queryInclude = null, string queryOrderBy = null)
    //     {
    //         if (queryFilter != null)
    //         {


    //         }

    //         Repository.GetAsync();
    //         throw new NotImplementedException();
    //     }

    //     public Task<Response<IReadOnlyList<TDto>>> GetAsync(string queryFilter = null, string queryInclude = null, string queryOrderBy = null)
    //     {
    //         throw new NotImplementedException();
    //     }

        public virtual async Task<Response<bool>> IfExits(int id)
        {
            return new Response<bool>
            {
                Data = await Repository.IfExistAsync(id),
                IsSuccess = true,
            };
        }

        public async Task<Response<TDto>> UpdateAsync(TDto item, int languageId)
        {
            ValidationResult validationResult = await Validator.ValidateAsync(new ValidationContext<TDto>(item));


            if (!validationResult.IsValid)
            {
                List<SimpleErrorDto> errors = new List<SimpleErrorDto>();
                foreach (string errorCode in validationResult.Errors.Select(x => x.ErrorCode).ToList())
                {
                    errors.Add(await _errorService.GetByCode(errorCode, languageId));
                }

                return new Response<TDto>{
                    IsSuccess=false,
                    Errors = errors,
                    Data=item
                };

            }


            T entity = await Repository.GetAsync(item.Id,true);

            if (entity == null)
            {
                return new Response<TDto>
                {
                    IsSuccess = false,
                };
            }

            entity = Mapper.Map(item, entity);


            bool result = await Repository.UpdateAsync(entity);

            item = Mapper.Map<TDto>(entity);
            return new Response<TDto>
            {
                Data = item,
                IsSuccess = result,
            };
        }
    }



}