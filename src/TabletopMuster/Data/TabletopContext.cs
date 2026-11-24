using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TabletopMuster.Models;

namespace TabletopMuster.Data {
    public class TabletopContext : IdentityDbContext<IdentityUser> {
        public DbSet<Unit> Units { get; set; }
        public DbSet<GameSystem> GameSystems { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<ArmyList> ArmyLists { get; set; }
        public DbSet<ArmyListEntry> ArmyListEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<ArmyListEntry>()
                .HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public TabletopContext(DbContextOptions<TabletopContext> options) : base(options) {
        }
    }
}