namespace BucketListTravel.Common.Models
{
    public interface ISoftDeletableEntity
    {
        public bool IsDeleted{ get; set; }
    }
}
