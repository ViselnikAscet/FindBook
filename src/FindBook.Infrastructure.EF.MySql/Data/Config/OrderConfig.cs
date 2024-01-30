using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class OrderConfig: IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Customer).WithMany(x=>x.Orders).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ShipmentAddress).WithMany(x=>x.ShipmentOrders).HasForeignKey(x=>x.ShipmentAddressId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.InvoiceAddress).WithMany(x=>x.InvoiceOrders).HasForeignKey(x=>x.InvoiceAddressId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.ShipmentMethod).WithMany(x=>x.Orders).HasForeignKey(x=>x.ShipmentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.PaymentMethod).WithMany(x=>x.Orders).HasForeignKey(x=>x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);



            builder.HasMany(x=>x.OrderDetails).WithOne(x=>x.Order).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Payments).WithOne(x=>x.Order).HasForeignKey(x=>x.OrderId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}