using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ProductCategoryConfig: IEntityTypeConfiguration<BooksCategory>
    {

        public void Configure(EntityTypeBuilder<BooksCategory> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.MainCategory).WithMany(x=>x.ChildCategory).HasForeignKey(x=>x.MainCategoryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.CampaignDetail).WithOne(x => x.GiftProductCategory).HasForeignKey(x => x.GiftProductCategoryId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}