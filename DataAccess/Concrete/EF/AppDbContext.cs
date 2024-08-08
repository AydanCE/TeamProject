using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=TeamProject;Trusted_Connection = true;TrustServerCertificate=true");

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<ProductDetail> ProductToSubCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<TermsAndCondition> TermsConditions { get; set; }
        public DbSet<AboutUs> Abouts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<OrderDetail> OrdersToProducts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
