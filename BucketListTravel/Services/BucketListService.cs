using BucketListTravel.Common.Enums;
using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Contracts;
using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Services
{
    public class BucketListService : IBucketListService
    {
        private readonly IBucketListRepository _bucketListRepository;
        private readonly IDestinationRepository _destinationRepository;

        public BucketListService(IBucketListRepository bucketListRepository,
            IDestinationRepository destinationRepository)
        {
            _bucketListRepository = bucketListRepository;
            _destinationRepository = destinationRepository;
        }

        public async Task<bool> AddAsync(int destinationId, string userId)
        {
            var destinationExists = await _destinationRepository
                .AllAsNoTracking()
                .AnyAsync(d => d.Id == destinationId);
            
            if (!destinationExists)
            {
                return false;
            }

            var alreadyInList = await _bucketListRepository
                .AllAsNoTracking()
                .AnyAsync(e => e.DestinationId == destinationId && e.UserId == userId);

            if (alreadyInList)
            {
                return false;
            }

            var entry = new BucketListEntry
            {
                DestinationId = destinationId,
                Status = VisitStatus.WantToVisit,
                DateAdded = DateTime.UtcNow,
                UserId = userId
            };

            await _bucketListRepository.AddAsync(entry);

            try
            {
                await _bucketListRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async Task<PagedResultDto<BucketListEntryDto>> GetAllAsync(string userId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            IQueryable<BucketListEntry> entriesQuery = _bucketListRepository
                .AllAsNoTracking()
                .Where(e => e.UserId == userId);

            int totalCount = await entriesQuery.CountAsync();

            IEnumerable<BucketListEntryDto> bucketListEntries = await entriesQuery
                .OrderByDescending(e => e.DateAdded)
                .ThenByDescending(e => e.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(e => new BucketListEntryDto
                {
                    Id = e.Id,
                    DestinationId = e.DestinationId,
                    DestinationName = e.Destination.Name,
                    Country = e.Destination.Country,
                    ImageUrl = e.Destination.ImageUrl,
                    CategoryName = e.Destination.Category.Name,
                    Status = e.Status,
                    PlannedDate = e.PlannedDate,
                    Notes = e.Notes,
                    DateAdded = e.DateAdded
                })
                .ToListAsync();

            return new PagedResultDto<BucketListEntryDto>
            {
                Items = bucketListEntries,
                TotalCount = totalCount
            };
        }

        public async Task<BucketListEntryForEditDto?> GetForEditAsync(int id, string userId)
        {
            return await _bucketListRepository
                .AllAsNoTracking()
                .Where(entry => entry.Id == id && entry.UserId == userId)
                .Select(entry => new BucketListEntryForEditDto
                {
                    Id = entry.Id,
                    DestinationName = entry.Destination.Name,
                    Status = entry.Status,
                    PlannedDate = entry.PlannedDate,
                    Notes = entry.Notes
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(UpdateBucketListEntryDto dto, string userId)
        {
            var entry = await _bucketListRepository.All()
                .FirstOrDefaultAsync(e => e.Id == dto.Id && e.UserId == userId);

            if (entry == null)
            {
                return false;
            }

            entry.Status = dto.Status;
            entry.PlannedDate = dto.Status == VisitStatus.Planned ? dto.PlannedDate : null;
            entry.Notes = dto.Notes;

            await _bucketListRepository.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> RemoveAsync(int destinationId, string userId)
        {
            var entry = await _bucketListRepository.All()
                .FirstOrDefaultAsync(e => e.DestinationId == destinationId && e.UserId == userId);

            if (entry == null)
            {
                return false;
            }
            
            _bucketListRepository.Remove(entry);
            await _bucketListRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
