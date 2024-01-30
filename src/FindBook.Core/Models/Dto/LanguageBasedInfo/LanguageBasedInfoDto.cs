using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Brand;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.FavoriteProduct;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.MenuItem;
using FindBook.Core.Models.Dto.MenuSection;
using FindBook.Core.Models.Dto.Oem;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Models.Dto.ProductCategory;
using FindBook.Core.Models.Dto.ProductImage;
using FindBook.Core.Models.Dto.ProductPrice;
using FindBook.Core.Models.Dto.ProductQuantity;
using FindBook.Core.Models.Dto.SeoInfo;
using FindBook.Core.Models.Dto.Vehicle;
using FindBook.Core.Models.Dto.VehicleBrand;
using FindBook.Core.Models.Dto.VehicleEngineCode;
using FindBook.Core.Models.Dto.VehicleModel;
using FindBook.Core.Models.Dto.VehicleYear;

namespace FindBook.Core.Models.Dto.LanguageBasedInfo

{

    public class LanguageBasedInfoDto : BaseEntityDto
    {

        public LanguageBasedInfoDto()
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
        public int? CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }
        public LanguageDto Language { get; set; }
        public BrandDto Brand { get; set; }
        public ProductCategoryDto ProductCategory { get; set; }
        public ProductDto Product { get; set; }
        public VehicleDto Vehicle { get; set; }
        public VehicleBrandDto VehicleBrand { get; set; }
        public VehicleModelDto VehicleModel { get; set; }
        public VehicleEngineCodeDto VehicleEngineCode { get; set; }
        public VehicleYearDto VehicleYear { get; set; }
        public int? MenuItemId { get; set; }
        public MenuItemDto MenuItem { get; set; }
        public int? MenuSectionId { get; set; }
        public MenuSectionDto MenuSection { get; set; }



    }


}