namespace TabletopMuster.Models {
    public class ArmyListEntry {
        public int Id { get; set; }

        public int ArmyListId { get; set; }
        public ArmyList ArmyList { get; set; } = null!;

        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;
    }
}
