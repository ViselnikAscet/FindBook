using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class CustomerConfig: IEntityTypeConfiguration<Customer>
    {
        

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
           builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x=>x.Addresses).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Baskets).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Orders).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.FavoriteProducts).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Payments).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.CustomerCars).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.EmailVerifications).WithOne(x=>x.Customer).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}