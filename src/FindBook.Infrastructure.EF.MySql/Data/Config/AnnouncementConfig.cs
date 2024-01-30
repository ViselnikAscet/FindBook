using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class AnnouncementConfig : IEntityTypeConfiguration<Announcement>
    {

        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
        }

    }


}