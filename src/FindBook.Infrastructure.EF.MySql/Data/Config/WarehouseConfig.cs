using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class WarehouseConfig: IEntityTypeConfiguration<Warehouse>
    {
        

        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Supplier).WithMany(x=>x.Warehouses).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductQuantities).WithOne(x=>x.Warehouse).HasForeignKey(x=>x.WarehouseId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}