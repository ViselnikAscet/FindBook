using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class VirtualPosParameterConfig : IEntityTypeConfiguration<VirtualPosParameter>
    {

        public void Configure(EntityTypeBuilder<VirtualPosParameter> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.VirtualPos).WithMany(x=>x.VirtualPosParameters).HasForeignKey(x=>x.VirtualPosId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}