using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.ViewModelValidation;
using static BucketListTravel.Common.EntityValidation;

namespace BucketListTravel.ViewModels.Destinations
{
    public class EditDestinationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ViewModelDestinationNameRequiredErrorMessage)]
        [MaxLength(DestinationNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ViewModelDestinationCountryRequiredErrorMessage)]
        [MaxLength(DestinationCountryMaxLength)]
        public string Country { get; set; } = null!;

        [MaxLength(DestinationDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(DestinationImageUrlMaxLength, ErrorMessage = ViewModelDestinationImageUrlMaxLengthErrorMessage)]
        [Url(ErrorMessage = ViewModelDestinationImageUrlInvalidErrorMessage)]
        public string? ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = ViewModelDestinationCategoryRequiredErrorMessage)]
        public int CategoryId { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}
