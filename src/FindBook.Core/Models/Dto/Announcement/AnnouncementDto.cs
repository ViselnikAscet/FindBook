using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Enum;
using FindBook.Core.Models.Dto.Base;

namespace FindBook.Core.Models.Dto.Announcement
{

    public class AnnouncementDto : BaseEntityDto
    {

        public string Name { get; set; }
        public string RedirectLink { get; set; }
        public string Image { get; set; }
        public AnnouncementType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }


}