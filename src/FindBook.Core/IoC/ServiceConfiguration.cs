using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FindBook.Core.IoC
{

    public static class ServiceConfiguration
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<ILanguageBasedInfoService, LanguageBasedInfoService>();
            services.AddTransient<IErrorService, ErrorService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<ICampaignService, CampaignService>();
            services.AddTransient<ICampaignDetailService, CampaignDetailService>();

            return services;
        }
    }
}