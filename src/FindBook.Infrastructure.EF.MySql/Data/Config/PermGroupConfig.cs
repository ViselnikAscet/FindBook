using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class PermGroupConfig: IEntityTypeConfiguration<PermGroup>
    {
        
        public void Configure(EntityTypeBuilder<PermGroup> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(x=>x.PermGroupPerms).WithOne(x=>x.PermGroup).HasForeignKey(x=>x.PermGroupId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}