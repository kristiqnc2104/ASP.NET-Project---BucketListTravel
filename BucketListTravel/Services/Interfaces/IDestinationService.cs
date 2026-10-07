using BucketListTravel.Data.Models;
using BucketListTravel.Services.DTOs;
namespace BucketListTravel.Services.Interfaces
{
    public interface IDestinationService
    {
        Task<IEnumerable<GetAllDestinationsDto>> GetAllDestinationsAsync();

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task CreateDestinationAsync(CreateDestinationDto model);
        
        Task<DestinationForEditDto?> GetDestinationByIdAsync(int id);

        Task<DestinationDetailsDto?> GetDestinationDetailsAsync(int id);

        Task<bool> UpdateDestinationAsync(UpdateDestinationDto model);

        Task DeleteRangeAsync(IEnumerable<int> selectedIds);
    }
}
