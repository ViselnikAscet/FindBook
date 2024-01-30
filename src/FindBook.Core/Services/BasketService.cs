using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Basket;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class BasketService : BaseService<Basket, BasketDto>, IBasketService
    {
        private protected readonly IBasketRepository _basketRepository;

        public BasketService(
            ILogger<BasketService> logger,
            IMapper mapper,
            IBasketRepository repository,
            IValidator<BasketDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _basketRepository = repository;

        }

        public async Task<Response<bool>> AddBasket(BasketDto basket, int languageId)
        {
            Response<bool> response = new Response<bool>();

            basket.Quantity = basket.Quantity == 0 ? 1 : basket.Quantity;

            Basket _entity = Mapper.Map<Basket>(basket);


            if (basket.CustomerId != null)
            {
                //Customer'imiz varsa
                var checkData = await _basketRepository.CheckHasProductInBasket(_entity.ProductId, 0, (int)basket.CustomerId);
                var result = false;
                if (checkData != null)
                {
                    if (basket.Quantity == 1)
                    {
                         checkData.Quantity = checkData.Quantity + 1;
                    }
                    else
                    {
                        checkData.Quantity = _entity.Quantity + checkData.Quantity;
                    }
                    result = await _basketRepository.UpdateAsync(checkData);
                }
                else
                {
                    result = await _basketRepository.AddAsync(_entity);
                }


                if (result == true)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Errors.Add(await _errorService.GetByCode("7010", languageId));
                    response.IsSuccess = false;
                }

            }
            else
            {

                //customer yoksa
                var checkData = await _basketRepository.CheckHasProductInBasket(_entity.ProductId, (int)_entity.BasketHeaderId, 0);
                var result = false;
                if (checkData != null)
                {
                    if (basket.Quantity == 1)
                    {
                         checkData.Quantity = checkData.Quantity + 1;
                    }
                    else
                    {
                        checkData.Quantity = _entity.Quantity;
                    }
                    result = await _basketRepository.UpdateAsync(checkData);
                }
                else
                {
                    result = await _basketRepository.AddAsync(_entity);
                }


                if (result == true)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Errors.Add(await _errorService.GetByCode("7010", languageId));
                    response.IsSuccess = false;
                }

            }



            return response;
        }

        public async Task<Response<List<BasketDto>>> GetBasketForProduct(int customerId, int basketHeaderId, int languageId)
        {
            Response<List<BasketDto>> response = new Response<List<BasketDto>>();

            var data = await _basketRepository.GetBasketForProduct(basketHeaderId, customerId);


            if (data != null)
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<BasketDto>>(data);

            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7011", languageId));
            }

            return response;
        }

        public async Task<Response<List<BasketDto>>> GetBasketForProductIdList(int customerId, int basketHeaderId, int languageId)
        {
            Response<List<BasketDto>> response = new Response<List<BasketDto>>();

            var data = await _basketRepository.GetBasketForProduct(basketHeaderId, customerId);


            if (data != null)
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<BasketDto>>(data);

            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7011", languageId));
            }

            return response;
        }

        public async Task<Response<List<BasketDto>>> GetCurrentBasketForCustomer(int customerId, int languageId)
        {
            Response<List<BasketDto>> response = new Response<List<BasketDto>>();

            var data = await _basketRepository.GetCurrentBasketForCustomer(customerId);

            if (data != null)
            {
                response.Data = Mapper.Map<List<BasketDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7011", languageId));
            }


            return response;
        }

        public async Task<Response<List<BasketDto>>> GetIsActiveBasket(int customerId, int basketHeaderId, int languageId, bool isLogged)
        {
            Response<List<BasketDto>> response = new Response<List<BasketDto>>();


            var result = await _basketRepository.GetIsActiveBasket(basketHeaderId, customerId, isLogged);


            if (result != null)
            {
                response.Data = Mapper.Map<List<BasketDto>>(result);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7011", languageId));
            }


            return response;
        }

        public async Task<Response<bool>> UpdatAllOrderItemIsActive(bool selectAll, int customerId, int basketHeaderId, int languageId)
        {
            Response<bool> response = new Response<bool>();

            var result = await _basketRepository.GetAllOrderForUser(basketHeaderId, customerId);

            foreach (var item in result)
            {
                if (!selectAll == false)
                {
                    item.IsActive = false;
                }
                else
                {
                    item.IsActive = true;
                }
                await _basketRepository.UpdateAsync(item);
            }

            var result2 = await _basketRepository.GetAllOrderForUser(basketHeaderId, customerId);


            return response;
        }

        public async Task<Response<bool>> UpdateIsActiveOrderItem(BasketDto basket, string caseType, int languageId)
        {
            Response<bool> response = new Response<bool>();

            var result = await _basketRepository.GetAsync(basket.Id, true);


            switch (caseType)
            {
                case "isActive":
                    result.IsActive = !basket.IsActive;
                    break;
                case "increaseQuantity":
                    result.Quantity = basket.Quantity + 1;
                    break;
                case "decreaseQuantity":
                    result.Quantity = basket.Quantity - 1;
                    break;
                case "delete":
                    result.IsDeleted = true;
                    break;
            }




            var updated = await _basketRepository.UpdateAsync(result);
            if (updated == true)
            {
                response.Data = updated;
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7012", languageId));
            }
            return response;
        }
    }


}