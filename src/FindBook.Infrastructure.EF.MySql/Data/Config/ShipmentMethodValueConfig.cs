using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ShipmentMethodValueConfig: IEntityTypeConfiguration<ShipmentMethodValue>
    {
        public void Configure(EntityTypeBuilder<ShipmentMethodValue> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.ShipmentMethod).WithMany(x=>x.ShipmentMethodValues).HasForeignKey(x=>x.ShipmentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ShipmentCompanyParameter).WithMany(x=>x.ShipmentMethodValues).HasForeignKey(x=>x.ShipmentCompanyParameterId).OnDelete(DeleteBehavior.NoAction);

            
        }

    }


}