using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class CampaignConfig : IEntityTypeConfiguration<Campaign>
    {


        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasMany(x => x.LanguageBasedInfos).WithOne(x => x.Campaign).HasForeignKey(x => x.CampaignId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.CampaignDetail).WithOne(x=>x.Campaign).HasForeignKey(x=>x.CampaignId).OnDelete(DeleteBehavior.NoAction);    


        }

    }


}