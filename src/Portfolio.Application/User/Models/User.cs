using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Portfolio.API.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}