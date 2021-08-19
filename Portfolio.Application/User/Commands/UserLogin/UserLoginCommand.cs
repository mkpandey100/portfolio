using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.User.Commands.UserLogin
{
    public class UserLoginCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public UserLoginCommandHandler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByEmailAsync(request.Email);
            var result = await _signInManager.PasswordSignInAsync(appUser, request.Password, false, false);
            if (result.Succeeded)
            {
                var test = result;
            }
            return true;
        }
    }
}