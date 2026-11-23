using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Common;
using BucketListTravel.Repository.Contracts;

namespace BucketListTravel.Repository
{
    public class DestinationRepository : BaseSoftDeletableRepository<Destination>, IDestinationRepository
    {
        public DestinationRepository(BucketListTravelDbContext context)
            : base(context)
        {
                     
        }
        

    }
}
