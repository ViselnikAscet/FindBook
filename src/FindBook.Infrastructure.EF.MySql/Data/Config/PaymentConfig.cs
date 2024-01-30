using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class PaymentConfig: IEntityTypeConfiguration<Payment>
    {
        

        public void Configure(EntityTypeBuilder<Payment> builder)
        {
             builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Customer).WithMany(x=>x.Payments).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Order).WithMany(x=>x.Payments).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.PaymentMethod).WithMany(x=>x.Payments).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.VirtualPos).WithMany(x=>x.Payments).HasForeignKey(x=>x.CustomerId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Currency).WithMany(x=>x.Payments).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);


        }

    }


}