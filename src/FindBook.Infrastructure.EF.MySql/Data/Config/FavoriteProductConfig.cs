using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class FavoriteProductConfig: IEntityTypeConfiguration<FavoriteProduct>
    {
        

        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
             builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Product).WithMany(x=>x.FavoriteProducts).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.FavoriteProducts).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}