using System.ComponentModel.DataAnnotations;

namespace BucketListTravel.Data.Models
{
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Photo> Photos { get; set; } = new List<Photo>();

        public ICollection<BucketListEntry> BucketListEntries { get; set; } = new List<BucketListEntry>();
    }
}
