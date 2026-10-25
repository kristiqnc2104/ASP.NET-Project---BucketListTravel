
using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly BucketListTravelDbContext _context;

        public DestinationService(BucketListTravelDbContext context)
        {
            _context = context;
        }

        public async Task CreateDestinationAsync(CreateDestinationDto model, string userId)
        {
            Destination destination = new Destination
            {
                Name = model.Name,
                Country = model.Country,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                OwnerId = userId
            };

            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<int> selectedIds, string userId)
        {
            var destinations = await _context.Destinations.Where(d => selectedIds.Contains(d.Id) && d.OwnerId == userId).ToArrayAsync();
            _context.Destinations.RemoveRange(destinations);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToArrayAsync();

            return categories;
        }

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            return _context.Categories.AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<GetAllDestinationsDto>> GetAllDestinationsAsync(string? userId)
        {
            IEnumerable<GetAllDestinationsDto> allDestinationsDtos = await _context.Destinations
                .AsNoTracking()
                .OrderBy(d => d.Name)
                .ThenBy(d => d.Country)
                .Select(d => new GetAllDestinationsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    ImageUrl = d.ImageUrl,
                    CategoryName = d.Category.Name,
                    IsInBucketList = _context.BucketListEntries.Any(ble => ble.DestinationId == d.Id && ble.UserId == userId)
                })
                .ToArrayAsync();

            return allDestinationsDtos;
        }

        public async Task<IEnumerable<GetAllDestinationsDto>> GetMyDestinationsAsync(string userId)
        {
            return await _context.Destinations
                .AsNoTracking()
                .Where(d => d.OwnerId == userId)
                .OrderBy(d => d.Name)
                .ThenBy(d => d.Country)
                .Select(d => new GetAllDestinationsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    ImageUrl = d.ImageUrl,
                    CategoryName = d.Category.Name,

                    IsInBucketList = _context.BucketListEntries.Any(bl =>
                        bl.DestinationId == d.Id &&
                        bl.UserId == userId)
                })
                .ToArrayAsync();
        }

        public async Task<DestinationForEditDto?> GetDestinationByIdAsync(int id, string userId)
        {
            DestinationForEditDto? destinationForEdit = await _context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id && d.OwnerId == userId)
                .Select(d => new DestinationForEditDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    CategoryId = d.CategoryId

                })
                .FirstOrDefaultAsync();

            return destinationForEdit;
        }

        public async Task<DestinationDetailsDto?> GetDestinationDetailsAsync(int id, string? userId)
        {
            DestinationDetailsDto? destinationDetails = await _context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DestinationDetailsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    CategoryName = d.Category.Name,
                    IsInBucketList = _context.BucketListEntries.Any(ble => ble.DestinationId == d.Id && ble.UserId == userId)
                })
                .FirstOrDefaultAsync();

            return destinationDetails;
        }

        public async Task<bool> UpdateDestinationAsync(UpdateDestinationDto model, string userId)
        {
            var destination = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == model.Id && d.OwnerId == userId);
            
            if (destination == null)
            {
                return false;
            }
            
            destination.Name = model.Name;
            destination.Country = model.Country;
            destination.Description = model.Description;
            destination.ImageUrl = model.ImageUrl;
            destination.CategoryId = model.CategoryId;

            await _context.SaveChangesAsync();

            return true;    
        }
    }
}
