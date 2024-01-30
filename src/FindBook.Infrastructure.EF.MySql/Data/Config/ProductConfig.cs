using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);


            builder.HasMany(x=>x.LanguageBasedInfos).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ProductCategory).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Oems).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.SeoInfos).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Baskets).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductVehicles).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductImages).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductQuantities).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ProductPrices).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.FavoriteProducts).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.CampaignDetail).WithOne(x => x.GiftProduct).HasForeignKey(x => x.GiftProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Brand).WithMany(x=>x.Products).HasForeignKey(x=>x.BrandId).OnDelete(DeleteBehavior.NoAction);

            // builder.Navigation(x=>x.LanguageBasedInfos).AutoInclude();



        }

    }


}