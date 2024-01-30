using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FindBook.Core.Entity.Base;
using FindBook.Core.Models;

namespace FindBook.Core.Interfaces.Services.Base
{

    public interface IBaseService<TDto>
    {

        Task<Response<TDto>> AddAsync(TDto item, int languageId);

        Task<Response<TDto>> UpdateAsync(TDto item, int languageId);
        Task<Response<TDto>> GetAsync(int id, int languageId, bool isTracking = false);
        Task<Response<IReadOnlyList<TDto>>> GetAsync(int languageId, bool isTracking = false, bool isActiveFilter = false, bool isActive = true);
        Task<Response<int>> CountAsync();
        Task<Response<bool>> IfExits(int id);
        // Task<Response<TDto>> GetAsync(int id, string queryFilter = null, string queryInclude = null, string queryOrderBy = null);
        // Task<Response<IReadOnlyList<TDto>>> GetAsync(string queryFilter = null, string queryInclude = null, string queryOrderBy = null);

    }

}