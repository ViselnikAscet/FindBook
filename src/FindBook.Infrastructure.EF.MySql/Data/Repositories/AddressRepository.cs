using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Address;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {

        public AddressRepository(AracaParcaContext context, ILogger<AddressRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<Address>> GetAddressByCustomerId(int customerId)
        {
            return await Table.Where(x => x.CustomerId == customerId).ToListAsync();
        }

    }


}