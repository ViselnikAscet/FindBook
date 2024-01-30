using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Entity
{

    public class MenuItem : BaseEntity
    {

        public MenuItem()
        {

        }
        public List<LanguageBasedInfo>? LanguageBasedInfos { get; set; }
        public string MenuIcon { get; set; }
        public string RedirectLink { get; set; }
        public int Priority { get; set; }
        public int? MenuSectionId { get; set; }
        public MenuSection MenuSection { get; set; }
        public UIMenuType MenuType { get; set; }
        public MenuItemType MenuItemType { get; set; } 
        public bool IsCustomLabel { get; set; } 
        public bool IsLogged { get; set; }
        public bool IsMobile { get; set; }

        public int? ProductCategoryId { get; set; }
        public int? VehicleBrandId { get; set; }
        public int? BrandId { get; set; }
        public BooksCategory ProductCategory { get; set; }
      
        


    }
}

