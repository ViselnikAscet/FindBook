using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Error;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Models.Dto.Perm;
using FindBook.Core.Models.Dto.PermGroup;
using FindBook.Core.Models.Dto.PermGroupPerm;
using FindBook.Core.Models.Dto.Resource;
using FindBook.Core.Models.Dto.SeoInfo;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Models.Dto.Setting;
using AutoMapper;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Models.Dto.Blog;
using FindBook.Core.Models.Dto.MenuSection;
using FindBook.Core.Models.Dto.MenuItem;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.CampaignDetail;

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
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, SimpleProductCategoryDto>().ReverseMap();
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