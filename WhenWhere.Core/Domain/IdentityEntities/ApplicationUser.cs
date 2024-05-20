using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhenWhere.Core.Domain.IdentityEntities
{
    /// <summary>
    /// user entity.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        [NotMapped]
        public string? FullName => $"{FirstName} {LastName}";

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
