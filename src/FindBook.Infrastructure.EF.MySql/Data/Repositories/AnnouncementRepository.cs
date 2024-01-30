using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Address;
using AracaParca.Core.Models.Enum;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {

        public AnnouncementRepository(AracaParcaContext context, ILogger<AnnouncementRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<Announcement>> GetAllAnnouncement()
        {
            return await Table.ToListAsync();
        }

        public async Task<Announcement> GetAnnouncementWithId(int announcementId) 
        {
            return await Table.Where(x => x.IsActive && x.Id == announcementId).FirstOrDefaultAsync();

        }

        public async Task<List<Announcement>> GetAnnouncementWithType(AnnouncementType type)
        {
            return await Table.Where(x=>x.IsActive && x.Type == type && x.Image != null && DateTime.Now <= x.EndDate &&  DateTime.Now >= x.StartDate ).ToListAsync();
        }
    }


}