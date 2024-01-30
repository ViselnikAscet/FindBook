using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class ClientConfig: IEntityTypeConfiguration<Client>
    {
        

        public void Configure(EntityTypeBuilder<Client> builder)
        {
           builder.HasQueryFilter(e => !e.IsDeleted);

          


        }

    }


}