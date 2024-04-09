using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebApplication1.Domain.Entities.User;


namespace WebApplication1.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base (nameOrConnectionString: "name=WebApplication1") 
        { 

        }

        public virtual DbSet<UDbTable> Users { get; set; }
    }
}
