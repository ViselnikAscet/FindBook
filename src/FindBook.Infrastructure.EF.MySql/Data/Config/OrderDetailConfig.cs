using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class OrderDetailConfig: IEntityTypeConfiguration<OrderDetail>
    {
        

        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Order).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Product).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ProductPrice).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.ProductPriceId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Supplier).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.NoAction);

            

           
        }

    }


}