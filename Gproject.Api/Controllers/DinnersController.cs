using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gproject.Api.Controllers
{
    [Route("[controller]")]

    public class DinnersController : ApiController
    {
        public DinnersController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {

        }
        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
