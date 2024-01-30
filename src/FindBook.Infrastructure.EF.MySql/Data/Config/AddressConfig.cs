using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            
            builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.InvoiceOrders).WithOne(x=>x.InvoiceAddress).HasForeignKey(x=>x.InvoiceAddressId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.ShipmentOrders).WithOne(x=>x.ShipmentAddress).HasForeignKey(x=>x.ShipmentAddressId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}
