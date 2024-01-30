using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Entity;

namespace FindBook.Core.Models.Dto.Book
{
    public class BookDto : BaseEntityDto


    {
        public BookDto(){

        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string PrintType { get; set; }
        public int LanguageId { get; set; }
        public string Thumbnail { get; set; }

        

    }
}