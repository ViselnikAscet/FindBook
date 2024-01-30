using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class SeoInfoConfig : IEntityTypeConfiguration<SeoInfo>
    {

        public void Configure(EntityTypeBuilder<SeoInfo> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Brand).WithMany(x => x.SeoInfos).HasForeignKey(x => x.BrandId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Blog).WithMany(x => x.SeoInfos).HasForeignKey(x => x.BlogId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Language).WithMany(x => x.SeoInfos).HasForeignKey(x => x.LanguageId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProductCategory).WithMany(x => x.SeoInfos).HasForeignKey(x => x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Product).WithMany(x => x.SeoInfos).HasForeignKey(x => x.ProductId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Vehicle).WithMany(x => x.SeoInfos).HasForeignKey(x => x.VehicleId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleBrand).WithMany(x => x.SeoInfos).HasForeignKey(x => x.VehicleId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.VehicleModel).WithMany(x => x.SeoInfos).HasForeignKey(x => x.VehicleModelId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.VehicleEngineCode).WithMany(x => x.SeoInfos).HasForeignKey(x => x.VehicleEngineCodeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.VehicleYear).WithMany(x => x.SeoInfos).HasForeignKey(x => x.VehicleYearId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);


        }

    }


}