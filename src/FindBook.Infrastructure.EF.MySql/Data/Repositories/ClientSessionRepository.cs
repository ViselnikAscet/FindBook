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

    public class ClientSessionRepository : BaseRepository<ClientSession>, IClientSessionRepository
    {

        public ClientSessionRepository(AracaParcaContext context, ILogger<ClientRepository> logger) : base(context, logger)
        {

        }

        public async Task<ClientSession> GetForRefresh(int clientId, string lastToken)
        {
           return await Table.Where(x=>x.ClientId==clientId && x.LastToken ==lastToken).FirstOrDefaultAsync();
        }
    }


}