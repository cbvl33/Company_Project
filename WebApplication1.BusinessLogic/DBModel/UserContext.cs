using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.User;
using WebApplication1.Domain.Entities.User.DbTable;

namespace WebApplication1.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base(nameOrConnectionString:"name=WebApplication1"){ }
        public virtual DbSet<UserDTO> Users { get; set; }
        public virtual DbSet<UDbAddInfo> AddInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDTO>()
                .HasOptional(l => l.AddInfo)
                .WithRequired(l => l.User);
        }
    }
}
