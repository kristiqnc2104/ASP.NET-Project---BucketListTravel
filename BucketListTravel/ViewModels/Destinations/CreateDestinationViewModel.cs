using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.EntityValidation;
using static BucketListTravel.Common.ViewModelValidation;

namespace BucketListTravel.ViewModels.Destinations
{
    public class CreateDestinationViewModel
    {
        [Required(ErrorMessage = ViewModelDestinationNameRequiredErrorMessage)]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ViewModelDestinationCountryRequiredErrorMessage)]
        [MaxLength(DestinationCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(DestinationDescriptionMaxLength)]
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ViewModelDestinationCategoryRequiredErrorMessage)]
        public int CategoryId { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
