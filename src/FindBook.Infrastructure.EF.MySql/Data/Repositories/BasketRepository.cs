using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
    {

        public BasketRepository(AracaParcaContext context, ILogger<BasketRepository> logger) : base(context, logger)
        {

        }

        public async Task<Basket> CheckHasProductInBasket(int productId, int basketHeaderId, int customerId)
        {
            return await Table.Where(
                x => x.IsActive &&
                x.ProductId == productId &&
                x.CustomerId == customerId || x.ProductId == productId &&
                x.BasketHeaderId == basketHeaderId && 
                x.IsTurnIntoOrder == false
                ).FirstOrDefaultAsync();
        }

        public async Task<List<Basket>> GetAllOrderForUser(int basketHeaderId, int customerId)
        {
            return await Table.Where(x => x.CustomerId == customerId || x.BasketHeaderId == basketHeaderId).ToListAsync();
        }

        public async Task<List<Basket>> GetBasketForProduct(int basketHeaderId, int customerId)
        {
            return await Table.Where(x => !x.IsTurnIntoOrder && x.CustomerId == customerId || x.BasketHeaderId == basketHeaderId)
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Product).ThenInclude(x => x.ProductPrices).ThenInclude(x => x.Currency)
            .Include(x => x.Product).ThenInclude(x => x.SeoInfos)
            .ToListAsync();
        }

        public async Task<List<Basket>> GetCurrentBasketForCustomer(int customerId)
        {
            return await Table.Where(x => x.CustomerId == customerId)
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Product).ThenInclude(x => x.ProductPrices).ThenInclude(x => x.Currency)
            .Include(x => x.Product).ThenInclude(x => x.SeoInfos)
            .ToListAsync();
        }

        public async Task<List<Basket>> GetIsActiveBasket(int basketHeaderId, int customerId, bool isLogged)
        {
            return await Table.Where(x => x.IsActive && !x.IsTurnIntoOrder && (isLogged && x.CustomerId == customerId) || (!isLogged && x.BasketHeaderId == basketHeaderId))
            .Include(x => x.Product).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.Product).ThenInclude(x => x.ProductPrices).ThenInclude(x => x.Currency)
            .Include(x => x.Product).ThenInclude(x => x.SeoInfos)
            .ToListAsync();
        }
    }

}