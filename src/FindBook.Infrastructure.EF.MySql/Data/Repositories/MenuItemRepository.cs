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

    public class MenuItemRepository : BaseRepository<MenuItem>, IMenuItemRepository
    {

        public MenuItemRepository(AracaParcaContext context, ILogger<MenuItemRepository> logger) : base(context, logger)
        {

        }

        public async Task<List<MenuItem>> GetAllMenuItems(int languageId)
        {
            return await Table.Where(x=>x.IsDeleted == false)
            .Include(x=>x.LanguageBasedInfos)
            .Include(x=>x.MenuSection).ThenInclude(x=>x.LanguageBasedInfos)
            .Include(x => x.Brand).ThenInclude(x => x.LanguageBasedInfo)
            .Include(x => x.Brand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.SeoInfos)
            .OrderBy(x=>x.Priority)
            .ToListAsync();
        }

        public async Task<List<MenuItem>> GetHeaderMenuItems(int languageId)
        {
            return await Table.Where(x => x.IsActive && x.MenuType == Core.Models.Enum.UIMenuType.Header)
            .Include(x=>x.LanguageBasedInfos)
            .Include(x => x.Brand).ThenInclude(x => x.LanguageBasedInfo)
            .Include(x => x.Brand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.SeoInfos)
            .OrderBy(x=>x.Priority)
            .ToListAsync();
        }

        public async Task<MenuItem> GetMenuWithId(int id)
        {
                      return await Table.Where(x => x.IsActive && x.Id == id)
            .Include(x => x.Brand).ThenInclude(x => x.LanguageBasedInfo)
            .Include(x => x.Brand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.VehicleBrand).ThenInclude(x => x.SeoInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.LanguageBasedInfos)
            .Include(x => x.ProductCategory).ThenInclude(x => x.SeoInfos)
            .FirstOrDefaultAsync();
        }
    }


}