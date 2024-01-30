using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ShipmentCompanyConfig : IEntityTypeConfiguration<ShipmentCompany>
    {
        public void Configure(EntityTypeBuilder<ShipmentCompany> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);


            builder.HasMany(x => x.ShipmentCompanyParameters).WithOne(x => x.ShipmentCompany).HasForeignKey(x => x.ShipmentCompanyId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ShipmentMethods).WithOne(x => x.ShipmentCompany).HasForeignKey(x => x.ShipmentCompanyId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}