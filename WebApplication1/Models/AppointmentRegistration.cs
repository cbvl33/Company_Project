using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Models
{
    public class AppointmentRegistration
    {
        [Required]
        public Experts Expert { get; set; }
        [Required]
        public string Notes { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public Services Service { get; set; }

        [Required]
        public Numbers Number { get; set; }
}

}