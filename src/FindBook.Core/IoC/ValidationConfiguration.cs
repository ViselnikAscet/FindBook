using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.LanguageBasedInfo;

using FindBook.Core.Models.Dto.Perm;
using FindBook.Core.Models.Dto.PermGroup;
using FindBook.Core.Models.Dto.PermGroupPerm;
using FindBook.Core.Models.Dto.Resource;
using FindBook.Core.Models.Dto.SeoInfo;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Services;
using FindBook.Core.Validation;
using FindBook.Core.Validation.Perm;
using FindBook.Core.Models.Dto.Setting;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Validation.Announcement;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.MenuItem;
using FindBook.Core.Models.Dto.MenuSection;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.Campaign;

namespace FindBook.Core.IoC
{

    public static class ValidationConfiguration
    {
        public static IServiceCollection RegisterValidations(this IServiceCollection services, IConfiguration configuration)
        {
         


            #region Error
            services.AddScoped<IValidator<ErrorDto>, ErrorDtoValidator>();
            services.AddScoped<IValidator<SimpleErrorDto>, SimpleErrorDtoValidator>();
            #endregion


            #region Langauge
            services.AddScoped<IValidator<LanguageDto>, LanguageDtoValidator>();
            services.AddScoped<IValidator<SimpleLanguageDto>, SimpleLanguageDtoValidator>();
            #endregion

            #region LangaugeBasedInfo
            services.AddScoped<IValidator<LanguageBasedInfoDto>, LangaugeBasedInfoDtoValidator>();
            services.AddScoped<IValidator<SimpleLanguageBasedInfoDto>, SimpleLangaugeBasedInfoDtoValidator>();
            #endregion

        

            #region Product
            services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();
            services.AddScoped<IValidator<SimpleProductDto>, SimpleProductDtoValidator>();
            #endregion

            #region ProductCategory
            services.AddScoped<IValidator<ProductCategoryDto>, ProductCategoryDtoValidator>();
            services.AddScoped<IValidator<SimpleProductCategoryDto>, SimpleProductCategoryDtoValidator>();
            #endregion

            #region Resource
            services.AddScoped<IValidator<ResourceDto>, ResourceDtoValidator>();
            services.AddScoped<IValidator<SimpleResourceDto>, SimpleResourceDtoValidator>();
            #endregion

            #region SeoInfo
            services.AddScoped<IValidator<SeoInfoDto>, SeoInfoDtoValidator>();
            services.AddScoped<IValidator<SimpleSeoInfoDto>, SimpleSeoInfoDtoValidator>();
            #endregion




            #region User
            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
            services.AddScoped<IValidator<SimpleUserDto>, SimpleUserDtoValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();

            #endregion

            #region Perm
            services.AddScoped<IValidator<PermDto>, PermDtoValidator>();
            services.AddScoped<IValidator<SimplePermDto>, SimplePermDtoValidator>();
            #endregion

            #region PermGroup
            services.AddScoped<IValidator<PermGroupDto>, PermGroupDtoValidator>();
            services.AddScoped<IValidator<SimplePermGroupDto>, SimplePermGroupDtoValidator>();
            services.AddScoped<IValidator<AddSettingDto>, AddSettingDtoValidator>();

            #endregion

            #region PermGroupPerm
            services.AddScoped<IValidator<PermGroupPermDto>, PermGroupPermDtoValidator>();
            services.AddScoped<IValidator<SimplePermGroupPermDto>, SimplePermGroupPermDtoValidator>();
            #endregion


            #region Setting
            services.AddScoped<IValidator<SettingDto>, SettingDtoValidator>();
            services.AddScoped<IValidator<SimpleSettingDto>, SimpleSettingDtoValidator>();
            services.AddScoped<IValidator<AddSettingDto>, AddSettingDtoValidator>();
            #endregion

           
            #region Announcements
            services.AddScoped<IValidator<AnnouncementDto>, AnnouncementDtoValidator>();
            #endregion

            #region Blog
            services.AddScoped<IValidator<BlogDto>, BlogDtoValidator>();
            #endregion


            #region Campaign
            services.AddScoped<IValidator<CampaignDto>, CampaignDtoValidator>();
            #endregion

            #region CampaignDetail
            services.AddScoped<IValidator<CampaignDetailDto>, CampaignDetailDtoValidator>();
            #endregion


            return services;
        }

    }


}