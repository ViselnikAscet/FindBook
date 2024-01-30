using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AracaParca.Core.Entity.Base;
using AracaParca.Core.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FindBook.Infrastructure.EF.MySql.Data.Repositories.Base
{

    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly AracaParcaContext DbContext;
        protected readonly ILogger Logger;
        protected readonly DbSet<T> Table;
        public BaseRepository(AracaParcaContext context, ILogger logger)
        {
            DbContext = context;
            Logger = logger;
            Table = DbContext.Set<T>();
        }


        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                var affectedRow = await DbContext.SaveChangesAsync();
                return affectedRow > 0;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }

        }

        protected void Log(Exception ex)
        {
            Logger.LogError(ex, "{@Exeption}", ex);
        }


        public virtual async Task<bool> AddAsync(T item)
        {
            item.CreatedAt = DateTime.Now;
            await Table.AddAsync(item);
            return await SaveChangesAsync();
        }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public virtual async Task<T> GetAsync(int id, bool isTracking = false)
        {
            if (isTracking)
            {
                return await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            return await Table.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetListAsync(bool isActiveFilter = false, bool isActive = true, bool isTracking = false)
        {
            if (isActiveFilter)
            {
                return await (isTracking ? Table.Where(x => x.IsActive == isActive).ToListAsync() : Table.AsNoTracking().Where(x => x.IsActive == isActive).ToListAsync());
            }
            else
            {
                return await (isTracking ? Table.ToListAsync() : Table.AsNoTracking().ToListAsync());
            }
        }

        public async Task<bool> IfExistAsync(int id)
        {
            return await Table.AnyAsync(entity => entity.Id == id);
        }

        public virtual async Task<bool> UpdateAsync(T item)
        {
            item.ModifiedAt = DateTime.Now;

            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    Table.Update(item);

                    var affectedRow = await DbContext.SaveChangesAsync();

                    T instance = await Table.Where(x => x.Id == item.Id).IgnoreQueryFilters().FirstOrDefaultAsync();

                    if (instance != null)
                    {
                        transaction.Commit();
                        return affectedRow > 0;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Log(ex);
                    return false;
                }
            }
        }

       
    }

}