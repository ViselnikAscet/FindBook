using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class PaymentMethodConfig: IEntityTypeConfiguration<PaymentMethod>
    {
        

        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x=>x.VirtualPoses).WithOne(x=>x.PaymentMethod).HasForeignKey(x=>x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Payments).WithOne(x=>x.PaymentMethod).HasForeignKey(x=>x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Orders).WithOne(x=>x.PaymentMethod).HasForeignKey(x=>x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}