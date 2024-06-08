using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.User;

namespace WebApplication1.BusinessLogic.DBModel
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext() :
            base("WebApplication1")
        { }
        public virtual DbSet<ADbTable> Users { get; set; }
    }
}
