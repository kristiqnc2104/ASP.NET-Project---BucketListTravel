using System.ComponentModel.DataAnnotations;

namespace BucketListTravel.Common.Enums
{
    public enum VisitStatus
    {
        [Display(Name = "Want to visit")]
        WantToVisit,
        Planned,
        Visited
    }
}
