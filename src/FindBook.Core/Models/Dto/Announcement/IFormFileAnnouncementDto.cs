using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Enum;
using FindBook.Core.Models.Dto.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace FindBook.Core.Models.Dto.Announcement
{

    public class IFormFileAnnouncementDto : BaseEntityDto
    {

        public string Name { get; set; }
        public string RedirectLink { get; set; }
        public IFormFile Image { get; set; }
        public AnnouncementType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }


}