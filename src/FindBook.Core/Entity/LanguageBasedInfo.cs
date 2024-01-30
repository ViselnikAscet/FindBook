using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class LanguageBasedInfo : BaseEntity
    {

        public LanguageBasedInfo()
        {

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductId { get; set; }
        public int? VehicleId { get; set; }
        public int? VehicleBrandId { get; set; }
        public int? VehicleModelId { get; set; }
        public int? VehicleEngineCodeId { get; set; }
        public int? VehicleYearId { get; set; }
        public int? CurrencyId { get; set; }
        public int? MenuItemId { get; set; }
        public int? MenuSectionId { get; set; }
        public int? CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public Language Language { get; set; }
        public MenuItem MenuItem { get; set; }
        public MenuSection MenuSection { get; set; }
       

    }


}