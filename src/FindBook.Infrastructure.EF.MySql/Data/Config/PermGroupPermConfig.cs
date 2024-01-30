using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class PermGroupPermConfig: IEntityTypeConfiguration<PermGroupPerm>
    {
        
        public void Configure(EntityTypeBuilder<PermGroupPerm> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.PermGroup).WithMany(x=>x.PermGroupPerms).HasForeignKey(x=>x.PermGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.Perm).WithMany(x=>x.PermGroupPerms).HasForeignKey(x=>x.PermId).OnDelete(DeleteBehavior.Cascade);


        }

    }


}