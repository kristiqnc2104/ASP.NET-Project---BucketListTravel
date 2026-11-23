using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Contracts.Common;

namespace BucketListTravel.Repository.Contracts
{
    public interface IDestinationRepository : ISoftDeletableRepository<Destination>
    {
    }
}
