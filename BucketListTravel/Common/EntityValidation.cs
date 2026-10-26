namespace BucketListTravel.Common
{
    public static class EntityValidation
    {
        //Category
        public const int CategoryNameMaxLength = 50;

        //BucketListEntry
        public const int BucketListEntryNotesMaxLength = 500;

        //Destination
        public const int DestinationNameMaxLength = 100;
        public const int DestinationCountryMaxLength = 100;
        public const int DestinationDescriptionMaxLength = 1000;
        public const int DestinationImageUrlMaxLength = 2048;
    }
}
