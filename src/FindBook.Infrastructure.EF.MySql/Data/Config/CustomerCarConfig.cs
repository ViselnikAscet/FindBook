using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindBook.Infrastructure.EF.MySql.Data.Config
{

    public class CustomerCarConfig: IEntityTypeConfiguration<CustomerCar>
    {
        

        public void Configure(EntityTypeBuilder<CustomerCar> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasOne(x=>x.Customer).WithMany(x=>x.CustomerCars).HasForeignKey(x=>x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x=>x.Vehicle).WithMany(x=>x.CustomerCars).HasForeignKey(x=>x.VehicleId).OnDelete(DeleteBehavior.NoAction);


            
        }

    }


}