namespace BucketListTravel.Common
{
    public static class ViewModelValidation
    {
        //Validation constants for Destination viewModels
        public const int ViewModelDestinationNameMaxLength = 100;
        public const int ViewModelDestinationCountryMaxLength = 100;
        public const int ViewModelDestinationDescriptionMaxLength = 1000;

        //Validation constants for BucketListEntry viewModels
        public const int ViewModelBucketListEntryNotesMaxLength = 500;

        //Error messages for validation of the Destination and BucketListEntry viewModels
        public const string ViewModelDestinationNameRequiredErrorMessage = "Destination name is required.";
        public const string ViewModelDestinationCountryRequiredErrorMessage = "Destination country is required.";
        public const string ViewModelDestinationCategoryRequiredErrorMessage = "Category is required.";
        public const string ViewModelDestinationCategoryNotFoundErrorMessage = "The selected category does not exist.";
        public const string ViewModelBucketListEntryStatusRequiredErrorMessage = "Status is required.";
        public const string ViewModelPlannedDateRequiredErrorMessage = "A planned date is required when the status is Planned.";
        public const string ViewModelPlannedDateInPastErrorMessage = "The planned date cannot be in the past.";
    }
}
