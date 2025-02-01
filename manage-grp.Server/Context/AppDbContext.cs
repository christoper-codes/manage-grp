using manage_grp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace manage_grp.Server.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }

    }
}
