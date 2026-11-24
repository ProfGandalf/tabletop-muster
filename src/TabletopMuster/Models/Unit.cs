using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TabletopMuster.Models {
    public class Unit {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; }
        public string Category { get; set; } = string.Empty;
        public string? Rules { get; set; }
        public string? StatsJson { get; set; }
        public byte[]? Image { get; set; }

        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;

        // null = jednostka z katalogu; wartość = własna jednostka użytkownika
        public string? AuthorId { get; set; }
        public IdentityUser? Author { get; set; }
    }
}
