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