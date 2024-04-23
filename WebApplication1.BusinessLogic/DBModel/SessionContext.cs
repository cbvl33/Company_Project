using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.User.DbTable;

namespace WebApplication1.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=WebApplication1") { }

        public virtual DbSet<UDbSession> Sessions { get; set; }
        //////
    }
}
