namespace WhenWhere.Core.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using WhenWhere.Core.CustomValidationAttributes;

    /// <summary>
    /// Event entity.
    /// </summary>
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ExpiredAt { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int Capacity { get; set; }

        public string Location { get; set; }

        public string? EventCreatorId { get; set; }

        [ForeignKey(nameof(EventCreatorId))]
        public virtual IdentityUser? EventCreator { get; set; }
    }
}
