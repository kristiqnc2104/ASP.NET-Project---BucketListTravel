namespace BucketListTravel.Services.DTOs
{
    public class CreateDestinationDto
    {
        public string Name { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

    }
}
