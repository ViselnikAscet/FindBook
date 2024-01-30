using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Enum;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class EmailVerificationRepository : BaseRepository<EmailVerification>, IEmailVerificationRepository
    {

        public EmailVerificationRepository(AracaParcaContext context, ILogger<EmailVerificationRepository> logger) : base(context, logger)
        {

        }

        public async Task<EmailVerification> GetByKeys(string key1, string key2, string key3 , EmailType type)
        {
            return await Table.Where(x=>x.Key1 == key1 && x.Key2 == key2 && x.Key3 == key3 && x.Type == type && x.IsActive).FirstOrDefaultAsync();
        }
    }


}