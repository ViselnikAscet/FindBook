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
            modelBuilder.ApplyConfiguration(new LanguageConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.ApplyConfiguration(new BooksConfig());
            modelBuilder.ApplyConfiguration(new LanguageBasedInfoConfig());
            modelBuilder.ApplyConfiguration(new ErrorConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());
            modelBuilder.ApplyConfiguration(new AnnouncementConfig());
            modelBuilder.ApplyConfiguration(new BlogConfig());
            modelBuilder.ApplyConfiguration(new CampaignConfig());
            modelBuilder.ApplyConfiguration(new CampaignDetailConfig());


        }
    }
}