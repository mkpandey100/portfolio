using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.User.Commands.CreateUser;
using Portfolio.Application.User.Commands.UserLogin;
using Portfolio.Core.API.Controllers;
using System;
using System.Threading.Tasks;

namespace Portfolio.API.Controllers.v1.UserAccount
{
    [Route("api/v1/[controller]")]
    [AllowAnonymous]
    public class UserController : BaseController
    {

        [HttpPost("register")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginCommand command)
        {
            try
            {
                var user = await Mediator.Send(command);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return CustomResponse("Kei milena ni!!");
            }
        }
    }
}