using BucketListTravel.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static BucketListTravel.Common.EntityValidation;
namespace BucketListTravel.Data.Models
{
    public class BucketListEntry
    {
        [Key]
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public virtual Destination Destination { get; set; } = null!;

        public VisitStatus Status { get; set; } = VisitStatus.WantToVisit;

        public DateTime? PlannedDate { get; set; }
        
        [MaxLength(BucketListEntryNotesMaxLength)]
        public string? Notes { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;
    }
}