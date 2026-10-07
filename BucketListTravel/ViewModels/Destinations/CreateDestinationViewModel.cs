using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.ViewModelValidation;

namespace BucketListTravel.ViewModels.Destinations
{
    public class CreateDestinationViewModel
    {
        [Required]
        [MaxLength(ViewModelDestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ViewModelDestinationCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(ViewModelDestinationDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
