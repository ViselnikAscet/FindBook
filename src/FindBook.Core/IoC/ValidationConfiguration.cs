using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Services;
using FindBook.Core.Validation;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Validation.Announcement;
using FindBook.Core.Models.Dto.Blog;

using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Validation.Book;
using FindBook.Core.Models.Dto.BookCategory;

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

        

            #region Book
            services.AddScoped<IValidator<BookDto>, BookDtoValidator>();

            #endregion

            #region BookCategory
            services.AddScoped<IValidator<BookCategoryDto>, BookCategoryDtoValidator>();
            #endregion




            #region User
            services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
            services.AddScoped<IValidator<SimpleUserDto>, SimpleUserDtoValidator>();
            services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();

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