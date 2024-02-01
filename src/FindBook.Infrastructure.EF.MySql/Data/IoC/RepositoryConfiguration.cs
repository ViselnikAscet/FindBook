using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Repositories;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Services;
using FindBook.Infrastructure.EF.MySql.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ICampaignDetailRepository = FindBook.Infrastructure.EF.MySql.Data.Repositories.ICampaignDetailRepository;
using ICampaignRepository = FindBook.Infrastructure.EF.MySql.Data.Repositories.ICampaignRepository;

namespace FindBook.Infrastructure.EF.MySql.Data.IoC
{

    public static class RepositoryConfiguration
    {

        public static IServiceCollection RegisterEfMysqlRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ILanguageBasedInfoRepository, LanguageBasedInfoRepository>();
            services.AddTransient<IErrorRepository, ErrorRepository>();
            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();
            services.AddTransient<IBlogRepository, BlogRepository>();
            services.AddTransient<ICampaignRepository, CampaignRepository>();
            services.AddTransient<ICampaignDetailRepository, CampaignDetailRepository>();


            return services;
        }
    }
}