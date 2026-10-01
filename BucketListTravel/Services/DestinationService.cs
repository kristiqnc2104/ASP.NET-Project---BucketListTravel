
using BucketListTravel.Data;
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


    }
}
