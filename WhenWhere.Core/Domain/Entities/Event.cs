namespace WhenWhere.Core.Domain.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using WhenWhere.Core.Domain.IdentityEntities;

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

        public Guid EventCreatorId { get; set; }

        [ForeignKey(nameof(EventCreatorId))]
        public virtual ApplicationUser? EventCreator { get; set; }
    }
}
