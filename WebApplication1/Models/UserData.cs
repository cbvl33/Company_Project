using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UserData
    {
        public string UserName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public List<List<string>> Appointment { get; set; }
        public string Notes { get; set; }
        


    }
}