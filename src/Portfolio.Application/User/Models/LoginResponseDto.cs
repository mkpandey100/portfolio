using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.User.Models
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}

