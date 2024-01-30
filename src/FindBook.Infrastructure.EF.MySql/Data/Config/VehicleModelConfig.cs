using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VehicleModelConfig : IEntityTypeConfiguration<VehicleModel>
    {

        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.VehicleBrand).WithMany(x => x.VehicleModels).HasForeignKey(x => x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.VehicleEngineCodes).WithOne(x => x.VehicleModel).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Vehicles).WithOne(x => x.VehicleModel).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.SeoInfos).WithOne(x => x.VehicleModel).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SeoInfos).WithOne(x => x.VehicleModel).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}