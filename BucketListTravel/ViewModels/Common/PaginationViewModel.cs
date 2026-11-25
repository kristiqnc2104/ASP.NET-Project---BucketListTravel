namespace BucketListTravel.ViewModels.Common
{
    public class PaginationViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }
}

