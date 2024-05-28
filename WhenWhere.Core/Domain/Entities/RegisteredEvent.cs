using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhenWhere.Core.Domain.Entities
{/// <summary>
/// registered event entity.
/// </summary>
    public class RegisteredEvent
    {
        public Guid Id { get; set; }

        public Guid? EventId { get; set; }

        public virtual Event? Event { get; set; }

        public string? UserId { get; set; }

        public virtual IdentityUser? User { get; set; }
    }
}
