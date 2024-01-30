using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ShipmentCompanyParameterConfig: IEntityTypeConfiguration<ShipmentCompanyParameter>
    {
        public void Configure(EntityTypeBuilder<ShipmentCompanyParameter> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.ShipmentCompany).WithMany(x=>x.ShipmentCompanyParameters).HasForeignKey(x=>x.ShipmentCompanyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ShipmentMethodValues).WithOne(x=>x.ShipmentCompanyParameter).HasForeignKey(x=>x.ShipmentCompanyParameterId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}