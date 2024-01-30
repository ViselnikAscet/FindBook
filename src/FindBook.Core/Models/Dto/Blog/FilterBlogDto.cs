using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.Customer;
using FindBook.Core.Models.Dto.Product;
using FindBook.Core.Models.Dto.ProductPrice;
using FindBook.Core.Models.Dto.SeoInfo;
using FindBook.Core.Models.Dto.User;

namespace FindBook.Core.Models.Dto.Blog
{

    public class FilterBlogDto 
    {

        public FilterBlogDto()
        {

        }

        public string Name { get; set; }
        public DateTime ShareStartDate { get; set; }
        public DateTime ShareEndDate { get; set; }
        public int UserId { get; set; }
    }


}