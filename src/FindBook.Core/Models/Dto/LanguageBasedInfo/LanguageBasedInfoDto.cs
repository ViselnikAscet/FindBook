using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Campaign;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.BookCategory;


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
        public int? BookCategoryId { get; set; }
        public int? BookId { get; set; }
        public int? VehicleId { get; set; }
        public int? VehicleBrandId { get; set; }
        public int? VehicleModelId { get; set; }
        public int? VehicleEngineCodeId { get; set; }
        public int? VehicleYearId { get; set; }
        public int? CampaignId { get; set; }
        public CampaignDto Campaign { get; set; }
        public LanguageDto Language { get; set; }
        public BookCategoryDto BookCategory { get; set; }
        public BookDto Book { get; set; }
     
        public int? MenuItemId { get; set; }
        public int? MenuSectionId { get; set; }



    }


}