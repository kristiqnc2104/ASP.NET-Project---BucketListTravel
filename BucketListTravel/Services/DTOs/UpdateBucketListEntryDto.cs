using BucketListTravel.Common.Enums;

namespace BucketListTravel.Services.DTOs
{
    public class UpdateBucketListEntryDto
    {
        public int Id { get; set; }

        public VisitStatus Status { get; set; }

        public DateTime? PlannedDate { get; set; }

        public string? Notes { get; set; }
    }
}
