using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserChangeEmail
    {
        public string Email { get; set; }
        public string NewEmail { get; set; }
        public string Password { get; set; }

    }
}