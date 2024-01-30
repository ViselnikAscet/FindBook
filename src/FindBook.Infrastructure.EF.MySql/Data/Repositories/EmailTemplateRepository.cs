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

    public class EmailTemplateRepository: BaseRepository<EmailTemplate>, IEmailTemplateRepository
    {
        
        public EmailTemplateRepository(AracaParcaContext context, ILogger<EmailTemplateRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<EmailTemplate> GetTemplate(string key, int languageId)
        {
                return await Table.Where(x=>x.Key == key && x.LanguageId == languageId).FirstOrDefaultAsync();
        }
    }


}