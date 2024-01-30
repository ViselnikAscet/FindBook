using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Order;
using FindBook.Core.Models.Enum;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class OrderService : BaseService<Order, OrderDto>, IOrderService
    {
        private protected readonly IOrderRepository _orderRepository;

        private readonly IBasketRepository _basketRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(
            ILogger<OrderService> logger,
            IMapper mapper,
            IOrderRepository repository,
            IValidator<OrderDto> validator,
            IBasketRepository basketRepository,
            IOrderDetailRepository orderDetailRepository,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _orderRepository = repository;
            _basketRepository = basketRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Response<List<OrderDto>>> GetOrderByCustomerId(int customerId, int languageId)
        {
            Response<List<OrderDto>> response = new Response<List<OrderDto>>();

            var data = await _orderRepository.GetOrderByCustomerId(customerId);

            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<OrderDto>>(data);
            }

            return response;
        }

        public async Task<Response<List<OrderDto>>> GetOrderByCustomerIdOrderStatu(int customerId, OrderStatu orderStatus, int languageId)
        {
            Response<List<OrderDto>> response = new Response<List<OrderDto>>();

            var data = await _orderRepository.GetOrderByCustomerIdOrderStatu(customerId, orderStatus);

            if (data == null)
            {
                response.IsSuccess = false;
            }
            else
            {
                response.IsSuccess = true;
                response.Data = Mapper.Map<List<OrderDto>>(data);
            }

            return response;
        }

        public async Task<Response<bool>> PostOrder(int basketHeaderId, bool isLogged, OrderDto orderDto, int customerId, int languageId)
        {
            Response<bool> response = new Response<bool>();
            orderDto.CustomerId = customerId;

            var entity = Mapper.Map<Order>(orderDto);
            var order = await _orderRepository.AddAsync(entity);

            if (order != false)
            {
                var orderdetail = await _basketRepository.GetIsActiveBasket(basketHeaderId, orderDto.CustomerId, isLogged);

                foreach (var item in orderdetail)
                {
                    item.IsTurnIntoOrder = true;
                    var updated = await _basketRepository.UpdateAsync(item);
                    if (updated == true)
                    {
                        OrderDetail orderDetailItem = new OrderDetail();
                        orderDetailItem.OrderId = entity.Id;
                        orderDetailItem.ProductId = item.ProductId;
                        orderDetailItem.ProductPriceId = item.AddedPriceId;
                        orderDetailItem.Quantity = item.Quantity;
                        orderDetailItem.SupplierId = 1;
                        var addedOrderDetail = await _orderDetailRepository.AddAsync(orderDetailItem);
                        if (addedOrderDetail != false)
                        {
                            response.Data = true;
                        }
                        else
                        {
                            response.IsSuccess = false;
                            return response;
                        }
                    }
                    else
                    {
                        response.IsSuccess = false;
                        return response;
                    }
                }
            }
            else
            {
                response.IsSuccess = false;
            }


            return response;
        }


        public async Task<Response<List<OrderDto>>> GetOrderWithFilter(SearchOrderDto searchOrderDto, int languageId)
        {
            Response<List<OrderDto>> response = new Response<List<OrderDto>>();

            var data = await _orderRepository.GetOrderWithFilter(searchOrderDto);


            if (data != null)
            {
                response.Data = Mapper.Map<List<OrderDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.Errors.Add(await _errorService.GetByCode("7014", languageId));
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<Response<OrderDto>> GetOrderWithId(int orderId, int languageId)
        {
            Response<OrderDto> response = new Response<OrderDto>();

            var data = await _orderRepository.GetOrderWithId(orderId);

            if (data != null)
            {
                response.Data = Mapper.Map<OrderDto>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("7014", languageId));
            }

            return response;
        }

        public async Task<Response<List<OrderDto>>> GetOrdersWithParams(FilterOrderDto filterOrderDto, int languageId)
        {
            Response<List<OrderDto>> response = new Response<List<OrderDto>>();

            var data = await _orderRepository.GetOrdersWithParams(filterOrderDto);

            if (data != null)
            {
                response.Data = Mapper.Map<List<OrderDto>>(data);
                response.IsSuccess = true;
            }
            else
            {
                response.IsSuccess = false;
                response.Errors.Add(await _errorService.GetByCode("", languageId));
            }

            return response;
        }
    }


}