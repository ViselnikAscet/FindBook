using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {

        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x => x.LanguageBasedInfo).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Errors).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Resources).WithOne(x => x.Language).HasForeignKey(x => x.LanguageId).OnDelete(DeleteBehavior.NoAction);
           

        }

    }


}