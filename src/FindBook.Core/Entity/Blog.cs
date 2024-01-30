using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Entity
{

    public class Blog : BaseEntity
    {

        public Blog()
        {

        }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public List<SeoInfo> SeoInfos { get; set; }
        public DateTime ShareStartDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}