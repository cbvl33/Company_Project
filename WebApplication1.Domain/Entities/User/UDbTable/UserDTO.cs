using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User
{
    public class UserDTOes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters.")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30, ErrorMessage = "Email cannot be longer than 30 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters.")]
        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [StringLength(30, ErrorMessage = "User IP cannot be longer than 30 characters.")]
        public string UserIp { get; set; }

        public Levels Levels { get; set; }
    }
}
