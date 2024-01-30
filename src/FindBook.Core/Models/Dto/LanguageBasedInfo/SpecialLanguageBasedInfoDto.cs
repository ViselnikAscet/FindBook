using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Brand;
using FindBook.Core.Models.Dto.FavoriteProduct;
using FindBook.Core.Models.Dto.Language;
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

    public class SpecialLanguageBasedInfoDto
    {

        public SpecialLanguageBasedInfoDto()
        {

            

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }       
        



    }


}