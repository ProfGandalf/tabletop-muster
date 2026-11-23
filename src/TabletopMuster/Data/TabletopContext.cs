using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TabletopMuster.Models;

namespace TabletopMuster.Data {
    public class TabletopContext : IdentityDbContext<IdentityUser> {
        public DbSet<Unit> Units { get; set; }

        public TabletopContext(DbContextOptions<TabletopContext> options) : base(options) {
        }
    }
}