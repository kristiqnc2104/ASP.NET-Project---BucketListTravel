using BucketListTravel.Common.Enums;

namespace BucketListTravel.Services.DTOs
{
    public class BucketListEntryForEditDto
    {
        public int Id { get; set; }

        public string DestinationName { get; set; } = null!;

        public VisitStatus Status { get; set; }

        public DateTime? PlannedDate { get; set; }

        public string? Notes { get; set; }
    }
}
