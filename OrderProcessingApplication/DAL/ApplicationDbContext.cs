using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderProcessingApplication.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<OrderData> OrderData { get; set; }
    }
}
