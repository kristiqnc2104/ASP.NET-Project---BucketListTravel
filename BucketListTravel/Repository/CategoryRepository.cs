using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Common;
using BucketListTravel.Repository.Contracts;

namespace BucketListTravel.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BucketListTravelDbContext context)
            : base(context)
        {
        }
    }
}