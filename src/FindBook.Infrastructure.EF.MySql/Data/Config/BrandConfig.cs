using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {


        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x => x.Products).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.OemCodes).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.SeoInfos).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.CampaignDetail).WithOne(x => x.GiftBrand).HasForeignKey(x => x.GiftBrandId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.LanguageBasedInfo).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}