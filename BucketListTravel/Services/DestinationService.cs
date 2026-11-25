
using BucketListTravel.Data;
using BucketListTravel.Data.Models;
using BucketListTravel.Repository.Contracts;
using BucketListTravel.Services.DTOs;
using BucketListTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BucketListTravel.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBucketListRepository _bucketListRepository;

        public DestinationService(
            IDestinationRepository destinationRepository,
            ICategoryRepository categoryRepository,
            IBucketListRepository bucketListRepository)
        {
            _destinationRepository = destinationRepository;
            _categoryRepository = categoryRepository;
            _bucketListRepository = bucketListRepository;
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

            await _destinationRepository.AddAsync(destination);
            await _destinationRepository.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<int> selectedIds, string userId)
        {
            var destinations = await _destinationRepository.All()
                .Where(d => selectedIds.Contains(d.Id) && d.OwnerId == userId)
                .ToArrayAsync();

            _destinationRepository.RemoveRange(destinations);
            await _destinationRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository
                .AllAsNoTracking()
                .OrderBy(c => c.Name)
                .ToArrayAsync();

            return categories;
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _categoryRepository
                .AllAsNoTracking()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<PagedResultDto<GetAllDestinationsDto>> GetAllDestinationsAsync(string? userId, int pageNumber, int pageSize)
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            IQueryable<Destination> destinationsQuery = _destinationRepository.AllAsNoTracking();

            int totalCount = await destinationsQuery.CountAsync();

            IEnumerable<GetAllDestinationsDto> allDestinationsDtos = await destinationsQuery
                .OrderBy(d => d.Name)
                .ThenBy(d => d.Country)
                .ThenBy(d => d.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new GetAllDestinationsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    ImageUrl = d.ImageUrl,
                    CategoryName = d.Category.Name,
                    IsInBucketList = _bucketListRepository.AllAsNoTracking().Any(ble => ble.DestinationId == d.Id && ble.UserId == userId)
                })
                .ToArrayAsync();

            return new PagedResultDto<GetAllDestinationsDto>
            {
                Items = allDestinationsDtos,
                TotalCount = totalCount
            };
        }

        public async Task<IEnumerable<GetAllDestinationsDto>> GetMyDestinationsAsync(string userId)
        {
            return await _destinationRepository.AllAsNoTracking()
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

                    IsInBucketList = _bucketListRepository
                        .AllAsNoTracking()
                        .Any(ble => 
                            ble.DestinationId == d.Id && 
                            ble.UserId == userId)
                })
                .ToArrayAsync();
        }

        public async Task<DestinationForEditDto?> GetDestinationByIdAsync(int id, string userId)
        {
            DestinationForEditDto? destinationForEdit = await _destinationRepository.AllAsNoTracking()
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
            DestinationDetailsDto? destinationDetails = await _destinationRepository.AllAsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DestinationDetailsDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Country = d.Country,
                    Description = d.Description,
                    ImageUrl = d.ImageUrl,
                    CategoryName = d.Category.Name,
                    IsInBucketList = _bucketListRepository
                        .AllAsNoTracking()
                        .Any(ble => 
                            ble.DestinationId == d.Id && 
                            ble.UserId == userId)
                })
                .FirstOrDefaultAsync();

            return destinationDetails;
        }

        public async Task<bool> UpdateDestinationAsync(UpdateDestinationDto model, string userId)
        {
            var destination = await _destinationRepository.All()
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

            await _destinationRepository.SaveChangesAsync();

            return true;    
        }
    }
}
