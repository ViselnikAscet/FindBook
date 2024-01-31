using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Models.Dto.Blog
{

    public class SearchBlogDto
    {

        public SearchBlogDto()
        {

        }

        public string Name { get; set; }
        public BlogOrderBy OrderBy { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }
    }


}