using FashionStoreTask.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreTask.DAL.Contexts
{
    public class AppDBContext : DbContext
    {
        private readonly string _ConnectionString = "Server=localhost;Database=FashionTaskDB;Trusted_Connection=True;TrustServerCertificate=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductDetails> productDetails { get; set; }
    }

}
