using BucketListTravel.Data;
using BucketListTravel.Repository.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Repository.Common
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected BucketListTravelDbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }

        protected BaseRepository(BucketListTravelDbContext context)
        {
            DbContext = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> All()
        {
            return DbSet
                .AsQueryable();
        }

        public virtual IQueryable<TEntity> AllAsNoTracking()
        {
            return DbSet
                .AsNoTracking()
                .AsQueryable();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.AddRange(entityCollection);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entityCollection)
        {
            await DbSet.AddRangeAsync(entityCollection);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.UpdateRange(entityCollection);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entityCollection)
        {
            DbSet.RemoveRange(entityCollection);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}
