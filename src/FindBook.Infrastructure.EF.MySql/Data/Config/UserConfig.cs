using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class UserConfig : IEntityTypeConfiguration<User>
    {

        public UserConfig()
        {

        }
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.Property(x => x.FullName).HasMaxLength(50).IsRequired();
            builder.HasMany(x=>x.Blogs).WithOne(x=>x.User).HasForeignKey(x=>x.UserId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);
        }
    }


}