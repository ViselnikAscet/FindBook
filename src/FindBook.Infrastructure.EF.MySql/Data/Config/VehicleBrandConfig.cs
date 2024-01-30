using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VehicleBrandConfig: IEntityTypeConfiguration<VehicleBrand>
    {
        
        public void Configure(EntityTypeBuilder<VehicleBrand> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x=>x.LanguageBasedInfos).WithOne(x=>x.VehicleBrand).HasForeignKey(x=>x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.VehicleModels).WithOne(x=>x.VehicleBrand).HasForeignKey(x=>x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.SeoInfos).WithOne(x=>x.VehicleBrand).HasForeignKey(x=>x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Vehicles).WithOne(x=>x.VehicleBrand).HasForeignKey(x=>x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}