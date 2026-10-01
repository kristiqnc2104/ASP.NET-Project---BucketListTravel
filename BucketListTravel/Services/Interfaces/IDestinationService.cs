using BucketListTravel.Services.DTOs;

namespace BucketListTravel.Services.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<GetAllDestinationsDto>> GetAllDestinationsAsync();
    }
}
