using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Infrastructure.EF.MySql.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace FindBook.Infrastructure.EF.MySql.Data
{
    public class FindBookContext : DbContext
    {
        public FindBookContext(DbContextOptions<FindBookContext> options) : base(options)
        {
        }

         public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BooksCategory> BooksCategories { get; set; }
        
        public DbSet<LanguageBasedInfo> LanguageBasedInfos { get; set; }

        public DbSet<Error> Errors { get; set; }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignDetail> CampaignDetails { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new TokenConfig());
            modelBuilder.ApplyConfiguration(new BrandConfig());
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new OemConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductVehicleConfig());
            modelBuilder.ApplyConfiguration(new ProductImageConfig());
            modelBuilder.ApplyConfiguration(new SeoInfoConfig());
            modelBuilder.ApplyConfiguration(new VehicleBrandConfig());
            modelBuilder.ApplyConfiguration(new VehicleConfig());
            modelBuilder.ApplyConfiguration(new VehicleEngineCodeConfig());
            modelBuilder.ApplyConfiguration(new VehicleModelConfig());
            modelBuilder.ApplyConfiguration(new VehicleYearConfig());

            modelBuilder.ApplyConfiguration(new LanguageBasedInfoConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new ProductPriceConfig());
            modelBuilder.ApplyConfiguration(new WarehouseConfig());
            modelBuilder.ApplyConfiguration(new ProductQuantityConfig());
            modelBuilder.ApplyConfiguration(new CurrencyConfig());

            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new BasketConfig());
            modelBuilder.ApplyConfiguration(new BasketHeaderConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());

            modelBuilder.ApplyConfiguration(new FavoriteProductConfig());
            modelBuilder.ApplyConfiguration(new CustomerCarConfig());

            modelBuilder.ApplyConfiguration(new ShipmentCompanyConfig());
            modelBuilder.ApplyConfiguration(new ShipmentCompanyParameterConfig());
            modelBuilder.ApplyConfiguration(new ShipmentMethodConfig());
            modelBuilder.ApplyConfiguration(new ShipmentMethodValueConfig());

            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new VirtualPosConfig());
            modelBuilder.ApplyConfiguration(new VirtualPosParameterConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new ErrorConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());

            modelBuilder.ApplyConfiguration(new PermConfig());
            modelBuilder.ApplyConfiguration(new PermGroupConfig());
            modelBuilder.ApplyConfiguration(new PermGroupPermConfig());

            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new ClientSessionConfig());

            modelBuilder.ApplyConfiguration(new SettingConfig());
            modelBuilder.ApplyConfiguration(new EmailSettingConfig());
            modelBuilder.ApplyConfiguration(new EmailTemplateConfig());

            modelBuilder.ApplyConfiguration(new EmailVerificationConfig());

            modelBuilder.ApplyConfiguration(new AnnouncementConfig());
            modelBuilder.ApplyConfiguration(new BlogConfig());
            modelBuilder.ApplyConfiguration(new MenuItemConfig());
            modelBuilder.ApplyConfiguration(new MenuSectionConfig());

            modelBuilder.ApplyConfiguration(new CampaignConfig());
            modelBuilder.ApplyConfiguration(new CampaignDetailConfig());


        }
    }
}