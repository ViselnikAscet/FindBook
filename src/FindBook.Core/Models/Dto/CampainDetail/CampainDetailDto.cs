using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.BookCategory;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Models.Dto.CampaignDetail
{

    public class CampaignDetailDto : BaseEntityDto
    {

        public CampaignDetailDto()
        {

        }

        public int CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }
        public int MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public int? SoldQuantity { get; set; }
        public int? DiscountPercentage { get; set; }
        public int? PriceAmount { get; set; }
        public int? GiftProductId { get; set; }
        public BookDto GiftProduct { get; set; }
        public int? GiftProductCategoryId { get; set; }
        public BookCategoryDto GiftProductCategory { get; set; }
        public CampaignGiftType CampaignGiftType { get; set; }
        public CampaignGroupType CampaignGroupType { get; set; }
        public int? GiftCampaignQuantity { get; set; }
        public int? GiftCampaignAmount { get; set; }
        public int? GiftCampaignDiscountPercentage { get; set; }
    }


}