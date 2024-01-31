using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Book;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Models.Dto.Blog
{

    public class SimpleBlogDto : BaseEntityDto
    {

        public SimpleBlogDto()
        {

        }

        public string Name { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }

        public DateTime ShareStartDate { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }


}