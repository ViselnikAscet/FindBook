using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VehicleEngineCodeConfig : IEntityTypeConfiguration<VehicleEngineCode>
    {

        public void Configure(EntityTypeBuilder<VehicleEngineCode> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.VehicleModel).WithMany(x => x.VehicleEngineCodes).HasForeignKey(x => x.VehicleModelId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.LanguageBasedInfos).WithOne(x => x.VehicleEngineCode).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.VehicleYears).WithOne(x => x.VehicleEngineCode).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.SeoInfos).WithOne(x => x.VehicleEngineCode).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Vehicles).WithOne(x => x.VehicleEngineCode).HasForeignKey(x => x.VehicleEngineCodeId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}