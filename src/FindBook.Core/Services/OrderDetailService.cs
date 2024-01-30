using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Interfaces.Helpers;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.OrderDetail;
using FindBook.Core.Models.Static;
using FindBook.Core.Services.Bases;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace FindBook.Core.Services
{

    public class OrderDetailService : BaseService<OrderDetail, OrderDetailDto>, IOrderDetailService
    {
        private protected readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRepository _orderRepository;
        protected readonly IEmailHelper _emailHelper;
        
        public OrderDetailService(
            ILogger<OrderDetailService> logger,
            IMapper mapper,
            IOrderDetailRepository repository,
            IOrderRepository orderRepository,
            IEmailHelper emailHelper,
            IValidator<OrderDetailDto> validator,
            IErrorService errorService) : base(logger, mapper, repository, validator, errorService)
        {
            _orderDetailRepository = repository;
            _orderRepository = orderRepository;
            _emailHelper = emailHelper;
        }

        public async Task<Response<bool>> UpdateOrderDetail(OrderDetailDto orderDetail, int languageId)
        {
            Response<bool> response = new Response<bool>();

            var orderDetailItem = await _orderDetailRepository.GetAsync(orderDetail.Id);


            if (orderDetailItem != null)
            {
                orderDetailItem.IsDeleted = true;
                var updateResult = await _orderDetailRepository.UpdateAsync(orderDetailItem);
                if (updateResult == true)
                {
                    response.Data = updateResult;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Data = false;
                    response.Errors.Add(await _errorService.GetByCode("7015", languageId));
                }
            }
            else
            {
                response.Data = false;
                response.Errors.Add(await _errorService.GetByCode("7015", languageId));
            }

            return response;
        }
    }


}