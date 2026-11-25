namespace BucketListTravel.ViewModels.Common
{
    public class PaginatedViewModel<T> : PaginationViewModel
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}

