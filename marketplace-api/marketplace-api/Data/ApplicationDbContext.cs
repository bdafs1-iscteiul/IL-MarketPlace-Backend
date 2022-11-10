using marketplace_api.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace marketplace_api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options) {
        }

        public DbSet<User> Users { get; set; }
    }
}
