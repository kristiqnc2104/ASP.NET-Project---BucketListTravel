using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.EntityValidation;
namespace BucketListTravel.Data.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DestinationCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(DestinationDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<Photo> Photos { get; set; } = new List<Photo>();

        public ICollection<BucketListEntry> BucketListEntries { get; set; } = new List<BucketListEntry>();
    }
}
