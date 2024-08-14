using Microsoft.EntityFrameworkCore;
using MVCCRUD.Models;

namespace MVCCRUD.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Emp> Emps { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
