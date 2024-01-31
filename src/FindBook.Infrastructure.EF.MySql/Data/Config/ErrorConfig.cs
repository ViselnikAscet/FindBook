using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ErrorConfig: IEntityTypeConfiguration<Error>
    {
        
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
           builder.HasOne(x=>x.Language).WithMany(x=>x.Errors).HasForeignKey(x=>x.LanguageId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}