using System;
using System.Collections.Generic;
using System.Linq;
using FindBook.Core.Entity;
using FindBook.Core.Entity.Base;
using FindBook.Core.Interfaces.Repositories.Base;
using FindBook.Core.Models.Enum;

namespace FindBook.Core.Interfaces.Repositories
{

    public interface IAnnouncementRepository : IBaseRepository<Announcement>
    {
        
        Task<List<Announcement>> GetAllAnnouncement();
        Task<Announcement> GetAnnouncementWithId(int announcementId);
        Task<List<Announcement>> GetAnnouncementWithType(AnnouncementType type);


    }


}