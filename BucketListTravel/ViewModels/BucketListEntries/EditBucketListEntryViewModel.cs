using BucketListTravel.Common.Enums;
using static BucketListTravel.Common.ViewModelValidation;
using System.ComponentModel.DataAnnotations;

namespace BucketListTravel.ViewModels.BucketListEntries
{
    public class EditBucketListEntryViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public string DestinationName { get; set; } = null!;

        [Required(ErrorMessage = ViewModelBucketListEntryStatusRequiredErrorMessage)]
        public VisitStatus Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Planned date")]
        public DateTime? PlannedDate { get; set; }

        [MaxLength(ViewModelBucketListEntryNotesMaxLength)]
        public string? Notes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == VisitStatus.Planned)
            {
                if (!PlannedDate.HasValue)
                {
                    yield return new ValidationResult(ViewModelPlannedDateRequiredErrorMessage, 
                        new[] { nameof(PlannedDate) });
                }
                else if (PlannedDate.Value.Date < DateTime.Today)
                {
                    yield return new ValidationResult(ViewModelPlannedDateInPastErrorMessage,
                        new[] { nameof(PlannedDate) });
                }
            }
        }
    }
}
