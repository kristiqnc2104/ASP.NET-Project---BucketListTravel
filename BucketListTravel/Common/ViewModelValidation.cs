namespace BucketListTravel.Common
{
    public static class ViewModelValidation
    {
        //Error messages for validation of the Destination and BucketListEntry viewModels
        public const string ViewModelDestinationNameRequiredErrorMessage = "Destination name is required.";
        public const string ViewModelDestinationCountryRequiredErrorMessage = "Destination country is required.";
        public const string ViewModelDestinationCategoryRequiredErrorMessage = "Category is required.";
        public const string ViewModelDestinationCategoryNotFoundErrorMessage = "The selected category does not exist.";
        public const string ViewModelBucketListEntryStatusRequiredErrorMessage = "Status is required.";
        public const string ViewModelPlannedDateRequiredErrorMessage = "A planned date is required when the status is Planned.";
        public const string ViewModelPlannedDateInPastErrorMessage = "The planned date cannot be in the past.";
        public const string ViewModelDestinationImageUrlMaxLengthErrorMessage = "The image URL cannot exceed {1} characters.";
        public const string ViewModelDestinationImageUrlInvalidErrorMessage = "The image URL is not valid.";
    }
}
