using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class BasketHeaderConfig: IEntityTypeConfiguration<BasketHeader>
    {
        

        public void Configure(EntityTypeBuilder<BasketHeader> builder)
        {
            builder.HasMany(x=>x.Baskets).WithOne(x=>x.BasketHeader).HasForeignKey(x=>x.BasketHeaderId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}