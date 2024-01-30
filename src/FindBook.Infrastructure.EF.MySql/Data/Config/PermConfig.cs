using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class PermConfig: IEntityTypeConfiguration<Perm>
    {
        
        public void Configure(EntityTypeBuilder<Perm> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(x=>x.PermGroupPerms).WithOne(x=>x.Perm).HasForeignKey(x=>x.PermId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}