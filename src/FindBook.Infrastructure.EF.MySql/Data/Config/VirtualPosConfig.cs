using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VirtualPosConfig: IEntityTypeConfiguration<VirtualPos>
    {
        
    
        public void Configure(EntityTypeBuilder<VirtualPos> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x=>x.VirtualPosParameters).WithOne(x=>x.VirtualPos).HasForeignKey(x=>x.VirtualPosId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Payments).WithOne(x=>x.VirtualPos).HasForeignKey(x=>x.VirtualPosId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.PaymentMethod).WithMany(x=>x.VirtualPoses).HasForeignKey(x=>x.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}