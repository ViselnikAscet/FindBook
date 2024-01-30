using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductPriceConfig : IEntityTypeConfiguration<ProductPrice>
    {
        
        public ProductPriceConfig()
        {
            
        }
        public void Configure(EntityTypeBuilder<ProductPrice> builder)
        {
            builder.HasOne(x=>x.Product).WithMany(x=>x.ProductPrices).HasForeignKey(x=>x.ProductId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Currency).WithMany(x=>x.ProductPrices).HasForeignKey(x=>x.CurrencyId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Supplier).WithMany(x=>x.ProductPrices).HasForeignKey(x=>x.SupplierId).IsRequired(false).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Baskets).WithOne(x=>x.AddedPrice).HasForeignKey(x=>x.BasketHeaderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.ProductPrice).HasForeignKey(x=>x.ProductPriceId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}