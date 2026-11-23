using System.ComponentModel.DataAnnotations;

namespace TabletopMuster.Models {
    public class Unit {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
        public byte[]? Image { get; set; }
        public string? Category { get; set; }
        public string? Rules { get; set; }
    }
}