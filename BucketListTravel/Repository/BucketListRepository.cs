using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Common;
using BucketListTravel.Repository.Contracts;

namespace BucketListTravel.Repository
{
    public class BucketListRepository : BaseRepository<BucketListEntry>, IBucketListRepository
    {
        public BucketListRepository(BucketListTravelDbContext context)
            : base(context)
        {
        }
    }
}