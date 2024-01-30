using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FindBook.Core.Entity.Base;

namespace FindBook.Core.Interfaces.Repositories.Base
{

    public interface IBaseRepository<T> where T : BaseEntity
    {

        Task<bool> AddAsync(T item); 
        Task<bool> UpdateAsync(T item);
        Task<T> GetAsync(int id, bool isTracking = false);
        Task<IReadOnlyList<T>> GetListAsync(bool isActiveFilter = false, bool isActive = true, bool isTracking = false);
        Task<int> CountAsync();
        Task<bool> IfExistAsync(int id);

        // #region Dynamics
        // Task<T> GetAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> include = null, Expression<Func<T, T>> orderBy = null);
        // Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> include = null, Expression<Func<T, T>> orderBy = null);
        // #endregion

    }

}