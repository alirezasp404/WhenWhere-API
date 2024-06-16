using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
namespace WhenWhere.Core.Domain.IdentityEntities
{
    /// <summary>
    /// user entity.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public string? FullName => $"{FirstName} {LastName}";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
