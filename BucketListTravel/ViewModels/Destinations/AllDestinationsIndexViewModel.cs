namespace BucketListTravel.ViewModels.Destinations
{
    public class AllDestinationsIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string CategoryName { get; set; } = null!;

        public bool IsInBucketList { get; set; }

    }
}
