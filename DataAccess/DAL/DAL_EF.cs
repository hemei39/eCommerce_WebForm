using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess
{
    public partial class DAL_EF : DbContext
    {
        public DAL_EF()
            : base("name=DAL_EF")
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);
        }

        public List<Product> GetProducts(int categoryID, string sortColumn)
        {
            string sql = "select * from Products where CategoryID=" + categoryID;
            if (!string.IsNullOrEmpty(sortColumn))
            {
                sql += " Order by " + sortColumn;
            }
            List<Product> products = new List<Product>();
            using (var dbContext = new DAL_EF())
            {
                products = dbContext.Products.SqlQuery(sql).ToList();
            }

            return products;
        }
    }
}
