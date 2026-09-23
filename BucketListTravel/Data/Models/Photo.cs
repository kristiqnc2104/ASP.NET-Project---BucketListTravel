using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.EntityValidation;
namespace BucketListTravel.Data.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [MaxLength(PhotoCaptionMaxLength)]
        public string? Caption { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; } = null!;
    }
}
