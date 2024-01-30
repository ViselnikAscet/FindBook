using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class SupplierConfig: IEntityTypeConfiguration<Supplier>
    {
    
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x=>x.ProductPrices).WithOne(x=>x.Supplier).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Warehouses).WithOne(x=>x.Supplier).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Supplier).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}