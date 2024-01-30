using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class MenuItemConfig : IEntityTypeConfiguration<MenuItem>
    {

        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.Property(x => x.MenuSectionId).IsRequired(false);
            builder.HasOne(x => x.MenuSection).WithMany(x => x.MenuItems).HasForeignKey(x => x.MenuSectionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.LanguageBasedInfos).WithOne(x => x.MenuItem).HasForeignKey(x => x.MenuItemId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Brand).WithMany(x => x.MenuItems).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.VehicleBrand).WithMany(x => x.MenuItems).HasForeignKey(x => x.VehicleBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.ProductCategory).WithMany(x => x.MenuItems).HasForeignKey(x => x.ProductCategoryId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}