using Microsoft.EntityFrameworkCore;
using TabletopMuster.Models;

namespace TabletopMuster.Data {
    public class TabletopContext : DbContext {
        public DbSet<Unit> Units { get; set; }

        public TabletopContext(DbContextOptions<TabletopContext> options) : base(options) {
        }
    }
}