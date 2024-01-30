using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductCategoryConfig: IEntityTypeConfiguration<ProductCategory>
    {

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.MainCategory).WithMany(x=>x.ChildCategory).HasForeignKey(x=>x.MainCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.LanguageBasedInfos).WithOne(x=>x.ProductCategory).HasForeignKey(x=>x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.SeoInfos).WithOne(x=>x.ProductCategory).HasForeignKey(x=>x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Products).WithOne(x=>x.ProductCategory).HasForeignKey(x=>x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.CampaignDetail).WithOne(x => x.GiftProductCategory).HasForeignKey(x => x.GiftProductCategoryId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}