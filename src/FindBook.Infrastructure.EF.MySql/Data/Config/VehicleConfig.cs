using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
    {

        public VehicleConfig()
        {

        }
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.VehicleBrand).WithMany(x => x.Vehicles).HasForeignKey(x => x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleModel).WithMany(x => x.Vehicles).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleEngineCode).WithMany(x => x.Vehicles).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleYear).WithMany(x => x.Vehicles).HasForeignKey(x => x.VehicleYearId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SeoInfos).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ProductVehicles).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.CustomerCars).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.LanguageBasedInfos).WithOne(x => x.Vehicle).HasForeignKey(x => x.VehicleId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}