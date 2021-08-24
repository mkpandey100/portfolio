using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core.API.Controllers;
using System.Threading.Tasks;

namespace Portfolio.API.Controllers.v1.Test
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Create()
        {
            return Ok("MIlyo");
        }
    }
}
