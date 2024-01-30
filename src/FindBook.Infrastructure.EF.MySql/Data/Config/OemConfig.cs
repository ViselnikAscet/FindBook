using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class OemConfig: IEntityTypeConfiguration<Oem>
    {
        
        public void Configure(EntityTypeBuilder<Oem> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Product).WithMany(x=>x.Oems).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Brand).WithMany(x=>x.OemCodes).HasForeignKey(x=>x.BrandId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}