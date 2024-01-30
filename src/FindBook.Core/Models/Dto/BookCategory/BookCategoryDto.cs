using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Entity;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.CampaignDetail;
using FindBook.Core.Models.Dto.LanguageBasedInfo;

namespace FindBook.Core.Models.Dto.BookCategory
{

    public class BookCategoryDto : BaseEntityDto
    {

        public BookCategoryDto(){

        }
         public int? MainCategoryId { get; set; }
        public BooksCategory MainCategory { get; set; }
        public List<BooksCategory> ChildCategory { get; set; }
        public List<BookDto> Books { get; set; }
        public List<LanguageBasedInfoDto> LanguageBasedInfos { get; set; }
        public string CategoryImage { get; set; }
        public List<CampaignDetailDto> CampaignDetail { get; set; }

    }
}