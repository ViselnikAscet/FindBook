using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class SettingConfig : IEntityTypeConfiguration<Setting>
    {

        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x => x.Language).WithMany(x => x.Settings).HasForeignKey(x => x.LanguageId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Currency).WithMany(x=>x.Settings).HasForeignKey(x=>x.CurrencyId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.SiteTitle).HasMaxLength(50).IsRequired(false);

        }

    }


}
