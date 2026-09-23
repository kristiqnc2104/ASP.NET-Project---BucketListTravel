using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.EntityValidation;
namespace BucketListTravel.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Destination> Destinations { get; set; } = new List<Destination>();
    }
}
