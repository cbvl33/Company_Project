using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Enums;

namespace WebApplication1.Domain.Entities.User
{
    public class ULoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserIP { get; set; }
        public DateTime LastLogin { get; set; }
        public string Name { get; set; }
        public Levels Level { get; set; }
    }
}
