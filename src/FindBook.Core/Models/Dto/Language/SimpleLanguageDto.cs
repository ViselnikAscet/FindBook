using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.Language
{

    public class SimpleLanguageDto: BaseEntityDto
    {
        
        public SimpleLanguageDto()
        {
            
        }
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public bool IsDefault { get; set; }


    }


}