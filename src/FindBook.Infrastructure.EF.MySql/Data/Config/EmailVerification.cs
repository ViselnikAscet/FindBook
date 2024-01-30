using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class EmailVerificationConfig: IEntityTypeConfiguration<EmailVerification>
    {
        
        public void Configure(EntityTypeBuilder<EmailVerification> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.EmailVerifications).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
        }

    }


}