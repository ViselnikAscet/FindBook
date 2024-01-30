using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class BooksCategory : BaseEntity
    {

        public BooksCategory()
        {

        }
        public int? MainCategoryId { get; set; }
        public BooksCategory MainCategory { get; set; }
        public List<BooksCategory> ChildCategory { get; set; }
        public List<Book> Books { get; set; }
        public List<LanguageBasedInfo> LanguageBasedInfos { get; set; }
        public string CategoryImage { get; set; }
        public List<SeoInfo> SeoInfos { get; set; }
        public List<MenuItem> MenuItems { get; set; }
        public List<CampaignDetail> CampaignDetail { get; set; }



    }


}