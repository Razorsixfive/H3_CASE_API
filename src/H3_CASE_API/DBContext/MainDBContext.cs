using Microsoft.EntityFrameworkCore;
using H3_CASE_API.Models;

namespace H3_CASE_API.DBContext
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options) { }


        public DbSet<Addrese> Addrese { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact_Informaition> Contact_Informaition { get; set; }
        public DbSet<Contact_Type> Contact_Type { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Delivery_Service> Delivery_Service { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manufactor> Manufactor { get; set; }
        public DbSet<OrderLine> OrderLine { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<PostalCodes> PostalCodes { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Product_Stock> Product_Stock { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Product_Status> Product_Status { get; set; }
    }
}
