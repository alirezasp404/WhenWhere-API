using System.ComponentModel.DataAnnotations.Schema;
using WhenWhere.Core.Domain.IdentityEntities;

namespace WhenWhere.Core.Domain.Entities
{/// <summary>
/// registered event entity.
/// </summary>
    public class RegisteredEvent
    {
        public Guid Id { get; set; }

        public Guid? EventId { get; set; }

        public virtual Event? Event { get; set; }

        public Guid? UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
