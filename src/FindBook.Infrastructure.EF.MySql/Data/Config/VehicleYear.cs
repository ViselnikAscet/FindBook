using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VehicleYearConfig : IEntityTypeConfiguration<VehicleYear>
    {
        public void Configure(EntityTypeBuilder<VehicleYear> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.VehicleEngineCode).WithMany(x => x.VehicleYears).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SeoInfos).WithOne(x => x.VehicleYear).HasForeignKey(x => x.VehicleYearId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Vehicles).WithOne(x => x.VehicleYear).HasForeignKey(x => x.VehicleEngineYearId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.LanguageBasedInfos).WithOne(x => x.VehicleYear).HasForeignKey(x => x.VehicleYearId).OnDelete(DeleteBehavior.NoAction);




        }

    }


}