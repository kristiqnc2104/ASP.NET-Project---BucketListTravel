
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

        public async Task CreateDestinationAsync(CreateDestinationDto model)
        {
            Destination destination = new Destination
            {
                Name = model.Name,
                Country = model.Country,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId
            };

            await _context.Destinations.AddAsync(destination);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<int> selectedIds)
        {
            var destinations = await _context.Destinations.Where(d => selectedIds.Contains(d.Id)).ToArrayAsync();
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

        public async Task<IEnumerable<GetAllDestinationsDto>> GetAllDestinationsAsync()
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
                    IsInBucketList = _context.BucketListEntries.Any(bl => bl.DestinationId == d.Id)
                })
                .ToArrayAsync();

            return allDestinationsDtos;
        }

        public async Task<DestinationForEditDto?> GetDestinationByIdAsync(int id)
        {
            DestinationForEditDto? destinationForEdit = await _context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == id)
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

        public async Task<DestinationDetailsDto?> GetDestinationDetailsAsync(int id)
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
                    IsInBucketList = _context.BucketListEntries.Any(bl => bl.DestinationId == d.Id)
                })
                .FirstOrDefaultAsync();

            return destinationDetails;
        }

        public async Task<bool> UpdateDestinationAsync(UpdateDestinationDto model)
        {
            Destination? destination = await _context.Destinations.FindAsync(model.Id);
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
