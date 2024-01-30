using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class CurrencyConfig: IEntityTypeConfiguration<Currency>
    {
        

        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(x=>x.LanguageBasedInfos).WithOne(x=>x.Currency).HasForeignKey(x=>x.CurrencyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Payments).WithOne(x=>x.Currency).HasForeignKey(x=>x.CurrencyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductPrices).WithOne(x=>x.Currency).HasForeignKey(x=>x.CurrencyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Settings).WithOne(x=>x.Currency).HasForeignKey(x=>x.CurrencyId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}