using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WhenWhere.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class APIController : ControllerBase
    {
    }
}
