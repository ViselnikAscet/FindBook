using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Interfaces.Services.Base;
using FindBook.Core.Models;
using FindBook.Core.Models.Dto.Announcement;
using FindBook.Core.Models.Dto.User;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Interfaces.Services
{

    public interface IAnnouncementService : IBaseService<AnnouncementDto>
    {
        Task<Response<List<AnnouncementDto>>> GetAllAnnouncement(int languageId);
        Task<Response<AnnouncementDto>> GetAnnouncementWithId(int announcementId, int languageId);
        Task<Response<List<AnnouncementDto>>> GetAnnouncementWithType(AnnouncementType type, int languageId);

        


    }


}