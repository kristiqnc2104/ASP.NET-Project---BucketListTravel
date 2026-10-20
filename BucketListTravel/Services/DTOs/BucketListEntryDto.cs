using BucketListTravel.Common.Enums;

namespace BucketListTravel.Services.DTOs
{
    public class BucketListEntryDto
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public string DestinationName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = null!;

        public VisitStatus Status { get; set; }

        public DateTime? PlannedDate { get; set; }

        public string? Notes { get; set; }

        public DateTime DateAdded { get; set; }     
    }
}
