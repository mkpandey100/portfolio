using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Application.User.Commands.CreateUser;
using Portfolio.Application.User.Commands.UserLogin;
using Portfolio.Core.API.Controllers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.API.Controllers.v1.UserAccount
{
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        private string SecretKey = "fmFGn5agHZkuG2N0e1zaEJIQtGVoNN5P";

        [HttpPost("register")]
        public async Task<ActionResult> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginCommand command)
        {
            var user = await Mediator.Send(command);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                    }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                Token = tokenString
            });
        }
    }
}