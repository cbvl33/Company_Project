using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Domain.Entities.User.DbTable
{
    public class UDbAddInfo
    {
        [Key, ForeignKey("User")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Photo { get; set; }
        public float Balance { get; set; }
        public UserDTO User { get; set; }

    }

}
