using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User.UDbTable
{
    public class ADbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Subject")]
        [StringLength(70)]
        public string Subject { get; set; }

        //[Required]
        //[Display(Name = "Service")]
        //public Services Service { get; set; }


        [Required]
        [Display(Name = "Notes")]
        [StringLength(10000)]
        public string Notes { get; set; }

        public ARole Status { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        public TimeSpan Time { get; set; }

        [Required]
        [Display(Name = "Expert")]
        public Experts Expert { get; set; }

        [Required]
        [Display(Name = "Service")]
        public Services Service { get; set; }

        [Required]
        [Display(Name = "Number")]
        public Numbers Number { get; set; }
    }
}
