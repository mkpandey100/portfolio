using MediatR;
using Microsoft.AspNetCore.Identity;
using Portfolio.Domain.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private UserManager<ApplicationUser> _userManager;

        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = request.Name,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(applicationUser, request.Password);
            return result.Succeeded;
        }
    }
}