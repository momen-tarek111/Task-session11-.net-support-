using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project3.Models;
namespace Project3.Database
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {


        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ContactForm> ContactForm { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        
    } 
}
