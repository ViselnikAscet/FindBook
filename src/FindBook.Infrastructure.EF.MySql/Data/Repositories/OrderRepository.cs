using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Order;
using AracaParca.Core.Models.Enum;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(AracaParcaContext context, ILogger<OrderRepository> logger) : base(context, logger)
        {
        }

        public async Task<List<Order>> GetOrderByCustomerId(int customerId)
        {
            return await Table.Where(x => x.IsActive && x.CustomerId == customerId).ToListAsync();
        }

        public async Task<List<Order>> GetOrderByCustomerIdOrderStatu(int customerId, OrderStatu orderStatus)
        {
            return await Table.Where(x => x.IsActive && x.CustomerId == customerId && x.OrderStatu == orderStatus)
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(c => c.ProductQuantities)
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(c => c.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.ProductPrices).ThenInclude(x => x.Currency)
            .Include(x => x.ShipmentAddress).Include(x => x.ShipmentMethod).Include(x => x.PaymentMethod).IgnoreQueryFilters().ToListAsync();
        }

        public async Task<List<Order>> GetOrdersWithParams(FilterOrderDto filterOrderDto)
        {
            return await Table.Where(x => x.IsActive && ((filterOrderDto.OrderStatu == -1) || (filterOrderDto.OrderStatu != -1 && x.OrderStatu == (OrderStatu)filterOrderDto.OrderStatu)) && x.CreatedAt > filterOrderDto.DateFilter).ToListAsync();
        }

        public async Task<List<Order>> GetOrderWithFilter(SearchOrderDto searchOrderDto)
        {
            return await Table
            .Where(x =>
            (
            ((searchOrderDto.CustomerFirstName != null && x.Customer.FirstName.Contains(searchOrderDto.CustomerFirstName)) || (searchOrderDto.CustomerFirstName == null))
            &&
           ((searchOrderDto.CustomerLastName != null && x.Customer.LastName.Contains(searchOrderDto.CustomerLastName)) || (searchOrderDto.CustomerLastName == null))
            &&
           ((!String.IsNullOrEmpty(searchOrderDto.CustomerEmail) && x.Customer.Email == searchOrderDto.CustomerEmail) || (String.IsNullOrEmpty(searchOrderDto.CustomerEmail)))
            &&
           ((!String.IsNullOrEmpty(searchOrderDto.CustomerPhoneNumber) && x.Customer.PhoneNumber == searchOrderDto.CustomerPhoneNumber) || (String.IsNullOrEmpty(searchOrderDto.CustomerPhoneNumber)))
            )
            &&
            ((searchOrderDto.OrderId != 0 && searchOrderDto.OrderId == x.Id) || (searchOrderDto.OrderId == 0))
             &&
            ((searchOrderDto.OrderStatus != -1 && (OrderStatu)searchOrderDto.OrderStatus == x.OrderStatu) || (searchOrderDto.OrderStatus == -1))

             &&
            ((searchOrderDto.PaymentMethodId != -1 && searchOrderDto.PaymentMethodId == x.PaymentMethodId) || (searchOrderDto.PaymentMethodId == -1))
            &&
            x.CreatedAt > searchOrderDto.StartCreatedAt
            &&
            x.CreatedAt < searchOrderDto.EndCreatedAt.AddDays(1))
            .Include(x => x.PaymentMethod)
            .ToListAsync();
        }

        public async Task<Order> GetOrderWithId(int orderId)
        {
            return await Table.Where(x => x.Id == orderId)
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.OrderDetails).ThenInclude(x => x.ProductPrice).ThenInclude(x => x.Currency)
            .Include(x => x.Customer)
            .Include(x => x.PaymentMethod)
            .Include(x => x.ShipmentMethod)
            .Include(x => x.Payments)
            .Include(x => x.InvoiceAddress).IgnoreQueryFilters()
            .Include(x => x.ShipmentAddress).IgnoreQueryFilters()
            .FirstOrDefaultAsync();
        }
    }



}