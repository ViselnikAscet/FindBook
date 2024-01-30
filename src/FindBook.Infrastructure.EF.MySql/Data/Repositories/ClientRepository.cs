using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Authentication;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {

        public ClientRepository(AracaParcaContext context, ILogger<ClientRepository> logger) : base(context, logger)
        {

        }

        public async Task<Client> GetForLogin(ClientLogin login)
        {
            return await Table.Where(x=>x.ApiKey==login.ApiKey && x.ApiSecretKey == login.ApiSecretKey).FirstOrDefaultAsync();
        }
    }


}