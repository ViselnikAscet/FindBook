using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Models.Dto.User;
using AutoMapper;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.BookCategory;

namespace FindBook.Core.Mapper
{

    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            #region User Mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, SimpleUserDto>().ReverseMap();
            #endregion

           

            #region Language Mapping
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Language, SimpleLanguageDto>().ReverseMap();
            #endregion


            #region ProductCategory Mapping
            CreateMap<BooksCategory, BookCategoryDto>().ReverseMap();
            CreateMap<BooksCategory, BookCategoryDto>().ReverseMap();
            #endregion

          

            #region LanguageBasedInfo Mapping
            CreateMap<LanguageBasedInfo, LanguageBasedInfoDto>().ReverseMap();
            CreateMap<LanguageBasedInfo, SimpleLanguageBasedInfoDto>().ReverseMap();
            CreateMap<LanguageBasedInfo, SpecialLanguageBasedInfoDto>().ReverseMap();
            #endregion
            
            #region Error
            CreateMap<Error, ErrorDto>().ReverseMap();
            CreateMap<Error, SimpleErrorDto>().ReverseMap();
            CreateMap<ErrorDto, SimpleErrorDto>().ReverseMap();
            #endregion

            #region Announcements
            CreateMap<Announcement, AnnouncementDto>().ReverseMap();
            #endregion  

            #region Blog
            CreateMap<Blog, BlogDto>().ReverseMap();
            #endregion

            #region Campaign
            CreateMap<Campaign, CampaignDto>().ReverseMap();
            #endregion  

            #region CampaignDetail
            CreateMap<CampaignDetail, CampaignDetailDto>().ReverseMap();
            #endregion  

        }
    }
}