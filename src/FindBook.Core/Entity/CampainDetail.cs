using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Entity
{

    public class CampaignDetail : BaseEntity
    {

        public CampaignDetail()
        {

        }


        public int CampaignId { get; set; }
        public Campaign Campaign { get; set; }
        public int MinQuantity { get; set; }
        public int? MaxQuantity { get; set; }
        public int? SoldQuantity { get; set; }
        public int? DiscountPercentage { get; set; }
        public int? PriceAmount { get; set; }
        public int? GiftProductId { get; set; }
        public Book GiftProduct { get; set; }
        public int? GiftProductCategoryId { get; set; }
        public BooksCategory GiftProductCategory { get; set; }
        public CampaignGiftType CampaignGiftType { get; set; }
        public CampaignGroupType CampaignGroupType { get; set; }
        public int? GiftCampaignQuantity { get; set; }
        public int? GiftCampaignAmount { get; set; }
        public int? GiftCampaignDiscountPercentage { get; set; }

    }


}