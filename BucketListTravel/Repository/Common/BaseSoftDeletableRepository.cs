using BucketListTravel.Common.Models;
using BucketListTravel.Data;
using BucketListTravel.Repository.Contracts.Common;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Repository.Common
{
    public abstract class BaseSoftDeletableRepository<TEntity>
        : BaseRepository<TEntity>, ISoftDeletableRepository<TEntity>
        where TEntity : class, ISoftDeletableEntity
    {
        public BaseSoftDeletableRepository(BucketListTravelDbContext context) : base(context)
        {
        }

        public IQueryable<TEntity> AllWithDeleted()
            => base.All().IgnoreQueryFilters();

        public IQueryable<TEntity> AllWithDeletedAsNoTracking()
            => base.AllAsNoTracking().IgnoreQueryFilters();

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
        }

        public void Recover(TEntity entity)
        {
            entity.IsDeleted = false;
        }

        public override void Remove(TEntity entity) => SoftDelete(entity);

        public override void RemoveRange(IEnumerable<TEntity> entityCollection)
        {
            foreach (TEntity entity in entityCollection)
            {
                SoftDelete(entity);
            }
        }
    }
}