using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Brand;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.Customer;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Models.Dto.ProductCategory;
using FindBook.Core.Models.Dto.ProductPrice;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Models.Dto.Campaign
{

    public class CampaignDto: BaseEntityDto
    {
        
        public CampaignDto()
        {
            
        }

        public List<LanguageBasedInfoDto> LanguageBasedInfos { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsMobile { get; set; }
        public CampaignType CampaignType { get; set; }
        public List<CampaignDetailDto>? CampaignDetail { get; set; }
        public int? CampaignDetailId { get; set; }
        public CampaignGroupType CampaignGroupType { get; set; }
        public int? ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int? ProductCategoryId { get; set; }
        public ProductCategoryDto? ProductCategory { get; set; }
        public int? BrandId { get; set; }
        public BrandDto? Brand { get; set; }
        public string CampaignName { get; set; }



        
    }


}