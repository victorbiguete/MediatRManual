using MediatRManual.Domain;
using Microsoft.EntityFrameworkCore;

namespace MediatRManual.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
