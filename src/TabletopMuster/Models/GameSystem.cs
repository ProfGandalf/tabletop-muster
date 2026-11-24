namespace TabletopMuster.Models {
    public class GameSystem {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public string CategoriesJson { get; set; } = "[]";
        public string StatDefinitionsJson { get; set; } = "[]";

        public List<Faction> Factions { get; set; } = new();
    }
}
