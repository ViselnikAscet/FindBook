using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {


        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.User).WithMany(x=>x.Blogs).HasForeignKey(x=>x.UserId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.NoAction);

        }

    }


}