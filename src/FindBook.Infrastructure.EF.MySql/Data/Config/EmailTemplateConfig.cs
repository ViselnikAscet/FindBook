using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class EmailTemplateConfig: IEntityTypeConfiguration<EmailTemplate>
    {
        
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.Language).WithMany(x=>x.EmailTemplates).HasForeignKey(x=>x.LanguageId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}
