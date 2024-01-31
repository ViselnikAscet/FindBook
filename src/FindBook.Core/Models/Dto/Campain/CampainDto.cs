using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.LanguageBasedInfo;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.BookCategory;
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
        public int? BookId { get; set; }
        public BookDto? Book { get; set; }
        public int? BookCategoryId { get; set; }
        public BookCategoryDto? BookCategory { get; set; }
        public string CampaignName { get; set; }



        
    }


}