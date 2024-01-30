using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductVehicleConfig : IEntityTypeConfiguration<ProductVehicle>
    {

        public void Configure(EntityTypeBuilder<ProductVehicle> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Vehicle).WithMany(x => x.ProductVehicles).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductVehicles).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}