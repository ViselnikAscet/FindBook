using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class BooksConfig : IEntityTypeConfiguration<Book>
    {
        

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);



        }


    }


}