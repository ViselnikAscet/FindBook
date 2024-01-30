using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Entity
{

    public class Campaign : BaseEntity
    {

        public Campaign()
        {

        }
        public List<LanguageBasedInfo> LanguageBasedInfos { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsMobile { get; set; }
        public CampaignType CampaignType { get; set; }
        public List<CampaignDetail> CampaignDetail { get; set; }
        public CampaignGroupType CampaignGroupType { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? BookCategoryId { get; set; }
        public BooksCategory ProductCategory { get; set; }
        public int? BrandId { get; set; }


    }


}