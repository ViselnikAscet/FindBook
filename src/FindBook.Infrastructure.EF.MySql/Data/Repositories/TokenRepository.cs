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

    public class TokenRepository : BaseRepository<Core.Entity.Token>, ITokenRepository
    {

        public TokenRepository(AracaParcaContext context, ILogger<TokenRepository> logger) : base(context, logger)
        {

        }

        public async Task<Core.Entity.Token> CheckModuleToken(int moduleCode)
        {
            return await Table.Where(x=>x.ModuleCode == moduleCode && x.ExpiredDate > DateTime.Now.AddSeconds(x.ExpiredInt) ).FirstOrDefaultAsync();
        }
    }


}