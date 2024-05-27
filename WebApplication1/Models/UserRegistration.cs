using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.User
{

    public class UserRegistration
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}