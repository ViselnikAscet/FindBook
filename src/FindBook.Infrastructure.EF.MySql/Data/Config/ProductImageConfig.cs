using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        
        public ProductImageConfig()
        {
            
        }
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}