using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductQuantityConfig : IEntityTypeConfiguration<ProductQuantity>
    {

        public void Configure(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductQuantities).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Warehouse).WithMany(x => x.ProductQuantities).HasForeignKey(x => x.WarehouseId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}