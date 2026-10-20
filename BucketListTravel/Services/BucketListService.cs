using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Common.Enums;
using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Services
{
    public class BucketListService : IBucketListService
    {
        private readonly BucketListTravelDbContext _context;

        public BucketListService(BucketListTravelDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(int destinationId)
        {
            var destinationExists = await _context.Destinations
                .AnyAsync(d => d.Id == destinationId);
            
            if (!destinationExists)
            {
                return false;
            }

            var alreadyInList = await _context.BucketListEntries
                .AnyAsync(e => e.DestinationId == destinationId);
            
            if (alreadyInList)
            {
                return false;
            }

            var entry = new BucketListEntry
            {
                DestinationId = destinationId,
                Status = VisitStatus.WantToVisit,
                DateAdded = DateTime.UtcNow
            };

            _context.BucketListEntries.Add(entry);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<BucketListEntryDto>> GetAllAsync()
        {
            IEnumerable<BucketListEntryDto> bucketListEntries = await _context.BucketListEntries
                .AsNoTracking()
                .OrderByDescending(e => e.DateAdded)
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

            return bucketListEntries;
        }

        public async Task<BucketListEntryForEditDto?> GetForEditAsync(int id)
        {
            return await _context.BucketListEntries
                .AsNoTracking()
                .Where(entry => entry.Id == id)
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

        public async Task<bool> UpdateAsync(UpdateBucketListEntryDto dto)
        {
            var entry = await _context.BucketListEntries.FindAsync(dto.Id);
            if (entry == null)
            {
                return false;
            }

            entry.Status = dto.Status;
            entry.PlannedDate = dto.Status == VisitStatus.Planned ? dto.PlannedDate : null;
            entry.Notes = dto.Notes;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveAsync(int destinationId)
        {
            var entry = await _context.BucketListEntries
                .FirstOrDefaultAsync(e => e.DestinationId == destinationId);

            if (entry == null)
            {
                return false;
            }

            _context.BucketListEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
