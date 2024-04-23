using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.User.DbTable;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User
{
    public class UserDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "UserName")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The username must be between 5 - 50 characters")]
        public string UserName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email is incorrect")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastLogin { get; set; }
        public DateTime Created { get; set; }
        public string UserIp { get; set; }
        public Levels Levels { get; set; }
        [Required]
        public UDbAddInfo AddInfo { get; set; }

    }
}