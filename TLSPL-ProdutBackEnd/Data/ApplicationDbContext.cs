using Microsoft.EntityFrameworkCore;
using TLSPL_ProdutBackEnd.Models;

namespace TLSPL_ProdutBackEnd.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<Assets> Assets { get; set; }
    }
}
