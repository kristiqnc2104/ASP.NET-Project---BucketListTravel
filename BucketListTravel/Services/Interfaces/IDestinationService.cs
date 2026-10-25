using BucketListTravel.Data.Models;
using BucketListTravel.Services.DTOs;
namespace BucketListTravel.Services.Interfaces
{
    public interface IDestinationService
    {
        Task CreateDestinationAsync(CreateDestinationDto model, string userId);

        Task DeleteRangeAsync(IEnumerable<int> selectedIds, string userId);

        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<IEnumerable<GetAllDestinationsDto>> GetAllDestinationsAsync(string? userId);

        Task<IEnumerable<GetAllDestinationsDto>> GetMyDestinationsAsync(string userId);

        Task<DestinationForEditDto?> GetDestinationByIdAsync(int id, string userId);

        Task<DestinationDetailsDto?> GetDestinationDetailsAsync(int id, string? userId);

        Task<bool> UpdateDestinationAsync(UpdateDestinationDto model, string userId);
    }
}
