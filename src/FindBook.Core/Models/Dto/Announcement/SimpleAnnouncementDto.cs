using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Models.Enum;
using FindBook.Core.Models.Dto.ClientSession;
using FindBook.Core.Models.Dto.Base;
using FindBook.Core.Models.Dto.UploadFile;

namespace FindBook.Core.Models.Dto.Announcement
{

    public class SimpleAnnouncementDto : BaseEntityDto
    {

        public string Name { get; set; }
        public string RedirectLink { get; set; }
        public UploadFileDto Image { get; set; }

        public AnnouncementType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


    }


}