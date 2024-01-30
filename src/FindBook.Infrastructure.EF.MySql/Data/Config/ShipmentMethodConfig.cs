using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ShipmentMethodConfig: IEntityTypeConfiguration<ShipmentMethod>
    {
        
   
        public void Configure(EntityTypeBuilder<ShipmentMethod> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.ShipmentCompany).WithMany(x=>x.ShipmentMethods).HasForeignKey(x=>x.ShipmentCompanyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ShipmentMethodValues).WithOne(x=>x.ShipmentMethod).HasForeignKey(x=>x.ShipmentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Orders).WithOne(x=>x.ShipmentMethod).HasForeignKey(x=>x.ShipmentMethodId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}