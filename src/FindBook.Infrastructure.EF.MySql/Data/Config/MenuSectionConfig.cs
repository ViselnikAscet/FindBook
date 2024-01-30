using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class MenuSectionConfig : IEntityTypeConfiguration<MenuSection>
    {

        public void Configure(EntityTypeBuilder<MenuSection> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(x => x.MenuItems).WithOne(x => x.MenuSection).HasForeignKey(x => x.MenuSectionId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}