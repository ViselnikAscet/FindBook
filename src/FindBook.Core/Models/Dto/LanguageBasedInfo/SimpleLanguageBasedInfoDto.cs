using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Language;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.BookCategory;

namespace FindBook.Core.Models.Dto.LanguageBasedInfo

{

    public class SimpleLanguageBasedInfoDto : BaseEntityDto
    {

        public SimpleLanguageBasedInfoDto()
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
        



    }


}