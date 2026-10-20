using BucketListTravel.Services.DTOs;

namespace BucketListTravel.Services.Interfaces
{
    public interface IBucketListService
    {
        Task<IEnumerable<BucketListEntryDto>> GetAllAsync();

        Task<BucketListEntryForEditDto?> GetForEditAsync(int id);

        Task<bool> UpdateAsync(UpdateBucketListEntryDto dto);

        Task<bool> AddAsync(int destinationId);

        Task<bool> RemoveAsync(int entryId);
    }
}
