 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User.Models
{
    public class UMinData
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public Levels Level { get; set; }
        public DateTime LastLogin { get; set; }
        public string UserIp { get; set; }
    }
}
