using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class LanguageBasedInfoConfig : IEntityTypeConfiguration<LanguageBasedInfo>
    {

        public LanguageBasedInfoConfig()
        {

        }
        public void Configure(EntityTypeBuilder<LanguageBasedInfo> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Language).WithMany(x => x.LanguageBasedInfo).HasForeignKey(x => x.LanguageId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Brand).WithMany(x => x.LanguageBasedInfo).HasForeignKey(x => x.BrandId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProductCategory).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Product).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.ProductId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Vehicle).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.VehicleId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleBrand).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.VehicleBrandId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleModel).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.VehicleModelId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleEngineCode).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.VehicleEngineCodeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleYear).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.VehicleYearId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Currency).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.CurrencyId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MenuItem).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.MenuItemId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MenuSection).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.MenuSectionId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Campaign).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.CampaignId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        }

    }


}