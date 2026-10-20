namespace BucketListTravel.ViewModels.BucketListEntries
{
    public class AllBucketListEntriesIndexViewModel
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public string DestinationName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Status { get; set; } = null!;

        public string? PlannedDate { get; set; }

        public string? Notes { get; set; }

        public string DateAdded { get; set; } = null!;
    }
}
