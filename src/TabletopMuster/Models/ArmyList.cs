using Microsoft.AspNetCore.Identity;

namespace TabletopMuster.Models {
    public class ArmyList {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PointsLimit { get; set; } = 2000;
        public DateTime UpdatedAt { get; set; }
        public bool IsImported { get; set; }

        public string OwnerId { get; set; } = string.Empty;
        public IdentityUser Owner { get; set; } = null!;

        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;

        public List<ArmyListEntry> Entries { get; set; } = new();
    }
}
