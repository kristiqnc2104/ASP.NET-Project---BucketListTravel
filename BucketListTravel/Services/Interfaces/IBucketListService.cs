using BucketListTravel.Services.DTOs;

namespace BucketListTravel.Services.Interfaces
{
    public interface IBucketListService
    {
        Task<IEnumerable<BucketListEntryDto>> GetAllAsync(string userId);

        Task<BucketListEntryForEditDto?> GetForEditAsync(int id, string userId);

        Task<bool> UpdateAsync(UpdateBucketListEntryDto dto, string userId);

        Task<bool> AddAsync(int destinationId, string userId);

        Task<bool> RemoveAsync(int destinationId, string userId);
    }
}
