using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class VirtualPosParameterRepository: BaseRepository<VirtualPosParameter>, IVirtualPosParameterRepository
    {
        
        public VirtualPosParameterRepository(AracaParcaContext context, ILogger<VirtualPosParameterRepository> logger) : base(context, logger)
        {
            
        }

        public async Task<VirtualPosParameter> CheckParameters(int virtualposId , string propertyName)
        {
            return await Table.Where(x=>x.VirtualPosId  == virtualposId && x.IsActive && x.PropertyName == propertyName).FirstOrDefaultAsync();
        }

        public Task<List<VirtualPosParameter>> GetVirtualPosParameterValue(int virtualposId)
        {
            return Table.Where(x=>x.VirtualPosId == virtualposId && x.IsActive).ToListAsync();
        }
    }


}