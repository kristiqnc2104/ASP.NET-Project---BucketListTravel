using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using BucketListTravel.Common.Models;
using static BucketListTravel.Common.EntityValidation;
namespace BucketListTravel.Data.Models
{
    public class Destination : ISoftDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DestinationCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(DestinationDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(DestinationImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<BucketListEntry> BucketListEntries { get; set; } = new List<BucketListEntry>();

        public string? OwnerId { get; set; }

        public virtual IdentityUser? Owner { get; set; }
    }
}
