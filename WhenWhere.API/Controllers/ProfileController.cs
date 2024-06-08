using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhenWhere.Core.DTO;

namespace WhenWhere.API.Controllers
{
    public class ProfileController : APIController
    {
        [HttpGet]
        public IActionResult GetProfile()
        {
            var profile = new ProfileDTO()
            {
                FirstName = User.FindFirst(ClaimTypes.Email)?.Value,
                LastName = User.FindFirst(ClaimTypes.Email)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
            };
            return Ok(profile);
        }
    }
}
