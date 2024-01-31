using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class LanguageBasedInfoConfig : IEntityTypeConfiguration<LanguageBasedInfo>
    {

        public LanguageBasedInfoConfig()
        {

        }
        public void Configure(EntityTypeBuilder<LanguageBasedInfo> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x => x.Language).WithMany(x => x.LanguageBasedInfo).HasForeignKey(x => x.LanguageId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MenuItem).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.MenuItemId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.MenuSection).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.MenuSectionId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Campaign).WithMany(x => x.LanguageBasedInfos).HasForeignKey(x => x.CampaignId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        }

    }


}