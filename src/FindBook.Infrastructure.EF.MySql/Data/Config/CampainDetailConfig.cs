using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class CampaignDetailConfig : IEntityTypeConfiguration<CampaignDetail>
    {


        public void Configure(EntityTypeBuilder<CampaignDetail> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x => x.GiftProductCategory).WithMany(x => x.CampaignDetail).HasForeignKey(x => x.GiftProductCategoryId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Campaign).WithMany(x => x.CampaignDetail).HasForeignKey(x => x.CampaignId).OnDelete(DeleteBehavior.NoAction) ;

        }

    }


}