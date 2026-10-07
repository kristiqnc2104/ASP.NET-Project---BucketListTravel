namespace BucketListTravel.Services.DTOs
{
    public class DestinationDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = null!;

        public bool IsInBucketList { get; set; }

    }
}
