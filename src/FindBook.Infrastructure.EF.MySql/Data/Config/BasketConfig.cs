using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class BasketConfig: IEntityTypeConfiguration<Basket>
    {
        
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
           builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Customer).WithMany(x=>x.Baskets).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.BasketHeader).WithMany(x=>x.Baskets).HasForeignKey(x=>x.BasketHeaderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Product).WithMany(x=>x.Baskets).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.AddedPrice).WithMany(x=>x.Baskets).HasForeignKey(x=>x.AddedPriceId).OnDelete(DeleteBehavior.NoAction);
          
        }

    }


}