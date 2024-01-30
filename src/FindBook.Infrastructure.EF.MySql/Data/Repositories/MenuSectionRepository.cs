using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using AracaParca.Core.Models.Dto.Address;
using AracaParca.Core.Models.Dto.Blog;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class MenuSectionRepository : BaseRepository<MenuSection>, IMenuSectionRepository
    {

        public MenuSectionRepository(AracaParcaContext context, ILogger<MenuSectionRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<MenuSection>> GetFooterMenuItems(int languageId)
        {
            return await Table.Where(x => x.IsActive)
            .Include(x => x.LanguageBasedInfos)
            .Include(x => x.MenuItems).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x => x.MenuItems).ThenInclude(x => x.Brand).ThenInclude(x => x.LanguageBasedInfo)
            .Include(x => x.MenuItems).ThenInclude(x => x.Brand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.MenuItems).ThenInclude(x => x.VehicleBrand).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.MenuItems).ThenInclude(x => x.VehicleBrand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.MenuItems).ThenInclude(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.MenuItems).ThenInclude(x => x.ProductCategory).ThenInclude(x => x.SeoInfos)

            .ToListAsync();
        }
    }


}