using Database.Interface;
using Microsoft.EntityFrameworkCore;

namespace Database.Repository
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected DatabaseContext Context { get; }
        protected DbSet<T> EntitySet { get; }

        protected BaseRepository(DatabaseContext databaseContext)
        {
            Context = databaseContext;
            EntitySet = Context.Set<T>();
        }

        #region public methods

        public virtual async Task<T> CreateAsync(T entity)
        {
            var entityEntry = await EntitySet.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await EntitySet.ToListAsync();
        }

        public virtual async Task<T>? GetAsync(Guid id)
        {
            return await EntitySet.FindAsync(id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var obj = EntitySet.Find(id);
            if (obj != null)
            {
                EntitySet.Remove(obj);
                await Context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
