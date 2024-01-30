using System;
using System.Collections.Generic;
using System.Linq;
using AracaParca.Core.Entity;
using AracaParca.Core.Interfaces.Repositories;
using FindBook.Infrastructure.EF.MySql.Data.Repositories.Base;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories
{

    public class VirtualPosRepository : BaseRepository<VirtualPos>, IVirtualPosRepository
    {

        public VirtualPosRepository(AracaParcaContext context, ILogger<VirtualPosRepository> logger) : base(context, logger)
        {

        }

        public async Task<VirtualPos> GetIdWithVPosEntegreId(int virtualposId)
        {
            return Table.Where(x => x.VPosEntegreId == virtualposId && x.IsActive).FirstOrDefault();
        }
    }


}