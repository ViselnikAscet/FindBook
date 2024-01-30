using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Entity
{

    public class Announcement : BaseEntity
    {

        public Announcement()
        {

        }
        public string Name { get; set; }
        public string RedirectLink { get; set; }
        public string Image { get; set; }
        public AnnouncementType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }


}