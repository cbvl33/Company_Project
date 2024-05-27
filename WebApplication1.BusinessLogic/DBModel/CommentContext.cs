using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Product.PDbTable;
using WebApplication1.Domain.Entities.User.UDbTable;

namespace WebApplication1.BusinessLogic.DBModel
{
    public class CommentContext : DbContext
    {
        public CommentContext() : base("name=WebApplication1") { }

        public virtual DbSet<CDbTable> Comment { get; set; }
    }
}
