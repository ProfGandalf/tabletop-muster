using System.ComponentModel.DataAnnotations;

namespace TabletopMuster.ViewModels;

// FRONTEND CONTRACT
// These classes are what the pages display. The backend fills them from the database
// (e.g. by mapping the EF entities); the views never touch the entities directly.
// Change a property here only together with the views that use it.

/// <summary>A game system (ruleset). Factions, units and army lists all belong to one system.</summary>
public class GameSystemVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    /// <summary>Short label shown above the system name, e.g. "Sci-fi battles".</summary>
    public string? Genre { get; set; }

    /// <summary>Unit categories in display order (the catalogue is grouped by these).</summary>
    public List<string> Categories { get; set; } = new();

    /// <summary>Stat columns this system uses, in display order (e.g. M, T, Sv, W, Ld, OC).</summary>
    public List<StatDefinitionVm> Stats { get; set; } = new();
}

public class StatDefinitionVm
{
    /// <summary>Short label used as the column header and as the key in <see cref="UnitVm.Stats"/>, e.g. "T".</summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>Full name shown as a tooltip, e.g. "Toughness".</summary>
    public string Name { get; set; } = string.Empty;
}

public class FactionVm
{
    public int Id { get; set; }
    public int SystemId { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class UnitVm
{
    public int Id { get; set; }
    public int FactionId { get; set; }
    public string FactionName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Points { get; set; }

    /// <summary>URL of the unit picture, or null to show the unit's initials instead.</summary>
    public string? ImageUrl { get; set; }

    /// <summary>Stat values keyed by <see cref="StatDefinitionVm.Key"/>. Values are text: "6\"", "3+", "D6".</summary>
    public Dictionary<string, string> Stats { get; set; } = new();

    /// <summary>Abilities and special rules, free text. Line breaks are kept.</summary>
    public string? Rules { get; set; }

    /// <summary>True for units created by a user (homebrew), false for the built-in catalogue.</summary>
    public bool IsCustom { get; set; }
    public string? AuthorName { get; set; }
}

/// <summary>One army list as shown on the main page.</summary>
public class ArmyListSummaryVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FactionId { get; set; }
    public string FactionName { get; set; } = string.Empty;
    public int PointsLimit { get; set; }
    public int PointsTotal { get; set; }
    public int UnitCount { get; set; }
    public DateTime UpdatedAt { get; set; }

    /// <summary>True if the list was imported rather than built in the app.</summary>
    public bool IsImported { get; set; }
}

/// <summary>The army list editor form (create and edit).</summary>
public class ArmyListInput
{
    [Required(ErrorMessage = "Give your army list a name.")]
    [StringLength(80, ErrorMessage = "Keep the name under 80 characters.")]
    [Display(Name = "List name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Choose a faction.")]
    [Display(Name = "Faction")]
    public int? FactionId { get; set; }

    [Range(1, 100000, ErrorMessage = "The points limit must be between 1 and 100,000.")]
    [Display(Name = "Points limit")]
    public int PointsLimit { get; set; } = 2000;

    /// <summary>One entry per squad. Adding the same unit twice gives two entries.</summary>
    public List<ArmyListEntryInput> Entries { get; set; } = new();
}

public class ArmyListEntryInput
{
    public int UnitId { get; set; }
}

/// <summary>Model for the _UnitCard partial. Picker = compact row with an "Add" button (army list editor).</summary>
public record UnitCardVm(UnitVm Unit, bool Picker);
