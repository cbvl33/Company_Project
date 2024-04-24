using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Domain.Entities.Product.PDbTable;

namespace WebApplication1.BusinessLogic.DBModel
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=WebApplication1") { }

        public virtual DbSet<PDbTable> PDbProducts { get; set; }
        public virtual DbSet<PDbDetail> PDbDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PDbTable>()
                .HasOptional(p => p.Details)
                .WithRequired(d => d.Product);

        }
    }
}
