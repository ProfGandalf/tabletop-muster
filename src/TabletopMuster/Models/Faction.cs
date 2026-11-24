namespace TabletopMuster.Models {
    public class Faction {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GameSystemId { get; set; }
        public GameSystem GameSystem { get; set; } = null!;
        public List<Unit> Units { get; set; } = new();
    }
}
