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

    public class EmailSettingRepository: BaseRepository<EmailSetting>, IEmailSettingRepository
    {
        
        public EmailSettingRepository(AracaParcaContext context, ILogger<EmailSettingRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<EmailSetting> GetSettingAsync()
        {
            return await Table.Where(x=>x.IsActive).FirstOrDefaultAsync();
        }
    }


}