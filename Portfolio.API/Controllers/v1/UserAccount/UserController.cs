using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.User.Commands.CreateUser;
using Portfolio.Application.User.Commands.UserLogin;
using Portfolio.Core.API.Controllers;
using System.Threading.Tasks;

namespace Portfolio.API.Controllers.v1.UserAccount
{
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok();
        }
    }
}