namespace TabletopMuster.ViewModels;

// TEMPORARY: made-up data so the frontend can be previewed before the database is ready.
// BACKEND TODO: once the page models load real data, delete this file and every call to SampleData.
public static class SampleData
{
    public static List<GameSystemVm> Systems { get; } = new()
    {
        new GameSystemVm
        {
            Id = 1,
            Name = "Iron Crusade",
            Genre = "Sci-fi battles",
            Categories = new() { "HQ", "Troops", "Elites", "Fast Attack", "Heavy Support" },
            Stats = new()
            {
                new() { Key = "M", Name = "Movement" },
                new() { Key = "T", Name = "Toughness" },
                new() { Key = "Sv", Name = "Save" },
                new() { Key = "W", Name = "Wounds" },
                new() { Key = "Ld", Name = "Leadership" },
                new() { Key = "OC", Name = "Objective Control" },
            },
        },
        new GameSystemVm
        {
            Id = 2,
            Name = "Realm of Embers",
            Genre = "Fantasy battles",
            Categories = new() { "Hero", "Infantry", "Cavalry", "Monster", "War Machine" },
            Stats = new()
            {
                new() { Key = "Move", Name = "Move" },
                new() { Key = "Save", Name = "Save" },
                new() { Key = "Health", Name = "Health" },
                new() { Key = "Control", Name = "Control" },
            },
        },
    };

    public static List<FactionVm> Factions { get; } = new()
    {
        new() { Id = 1, SystemId = 1, Name = "Iron Legion" },
        new() { Id = 2, SystemId = 1, Name = "Kharak Swarm" },
        new() { Id = 3, SystemId = 1, Name = "Ashen Covenant" },
        new() { Id = 4, SystemId = 2, Name = "Emberguard" },
        new() { Id = 5, SystemId = 2, Name = "Hollow Court" },
    };

    public static List<UnitVm> Units { get; } = new()
    {
        // Iron Crusade: M | T | Sv | W | Ld | OC
        U(1, 1, "Legion Castellan", "HQ", 95, "6\"|4|2+|5|6+|1",
            "Leader: can join a Legionnaire Squad.\nIron Will: once per battle, re-roll a failed Leadership test."),
        U(2, 1, "Legionnaire Squad", "Troops", 90, "6\"|4|3+|2|6+|2",
            "Hold the Line: +1 to saves while within range of an objective."),
        U(3, 1, "Breacher Team", "Elites", 130, "5\"|5|2+|3|6+|1",
            "Breaching Charges: ignore cover when attacking units in buildings."),
        U(4, 1, "Outrider Bikes", "Fast Attack", 110, "12\"|5|3+|3|6+|2",
            "Turbo Boost: can advance and still shoot."),
        U(5, 1, "Siege Walker", "Heavy Support", 160, "8\"|9|2+|10|7+|4",
            "Walking Fortress: cannot be pinned.\nSiege Cannon: double damage against vehicles."),
        U(6, 1, "Veteran Pathfinders", "Elites", 85, "7\"|4|4+|2|6+|1",
            "Scouts: deploy anywhere more than 9\" from the enemy.", custom: true),
        U(7, 2, "Hive Overseer", "HQ", 120, "8\"|6|4+|7|7+|1",
            "Synapse: friendly Swarm units within 6\" never fall back."),
        U(8, 2, "Swarmling Brood", "Troops", 60, "6\"|3|6+|1|8+|2",
            "Endless Swarm: once per battle, return D3 destroyed models."),
        U(9, 2, "Spitter Beasts", "Elites", 75, "6\"|5|4+|3|8+|1",
            "Acid Spray: attacks ignore armour on a 6."),
        U(10, 2, "Skitter Swarm", "Fast Attack", 50, "10\"|3|6+|2|8+|0",
            "Fast: may move again after shooting."),
        U(11, 2, "Burrowing Maw", "Heavy Support", 185, "7\"|10|3+|12|8+|3",
            "Tunnel: arrives from reserves anywhere on the battlefield."),
        U(12, 3, "Pyre Priest", "HQ", 70, "6\"|3|5+|4|7+|1",
            "Sermon of Flame: friendly units within 6\" re-roll charge rolls."),
        U(13, 3, "Cinder Cultists", "Troops", 55, "6\"|3|6+|1|7+|2", null),
        U(14, 3, "Ashwalkers", "Elites", 100, "5\"|4|5+|2|6+|1",
            "Smoulder: enemies within 3\" get -1 to hit."),
        U(15, 3, "Ember Chariot", "Heavy Support", 140, "10\"|8|3+|9|7+|3",
            "Firestorm: deals D3 damage to every unit it moves over."),

        // Realm of Embers: Move | Save | Health | Control
        U(16, 4, "Ember Knight-Captain", "Hero", 140, "5\"|3+|6|2",
            "Rally: once per turn, return D3 slain models to a nearby Infantry unit."),
        U(17, 4, "Hearthguard Spears", "Infantry", 110, "5\"|4+|1|1",
            "Spear Wall: +1 to hit against Cavalry."),
        U(18, 4, "Flamehoof Riders", "Cavalry", 180, "10\"|4+|3|2", null),
        U(19, 4, "Forge Ballista", "War Machine", 120, "3\"|5+|5|0",
            "Long Range: can target units up to 36\" away."),
        U(20, 5, "Hollow King", "Hero", 200, "5\"|3+|8|2",
            "Crown of Dust: enemy Heroes within 9\" get -1 to hit."),
        U(21, 5, "Grave Wardens", "Infantry", 100, "4\"|5+|1|1", null),
        U(22, 5, "Bone Wyrm", "Monster", 320, "12\"|4+|14|5",
            "Fly.\nTerror: enemy units within 6\" cannot use Rally."),
    };

    private static readonly List<SampleList> Lists = new()
    {
        new(1, 1, "Iron Legion spearhead", 1, 1000, new DateTime(2026, 11, 22, 18, 40, 0), false,
            new() { 1, 2, 2, 4, 5 }),
        new(2, 1, "Bug tide", 2, 2000, new DateTime(2026, 11, 20, 9, 15, 0), false,
            new() { 7, 7, 8, 8, 8, 8, 9, 9, 10, 10, 11, 11 }),
        new(3, 1, "Tournament Ashen (from Kuba)", 3, 750, new DateTime(2026, 11, 18, 21, 5, 0), true,
            new() { 12, 13, 13, 14, 14, 15, 15, 15 }),
        new(4, 1, "Kharak 500 test", 2, 500, new DateTime(2026, 11, 12, 16, 30, 0), false,
            new() { 7, 8, 8, 10 }),
        new(5, 2, "Emberguard host", 4, 1000, new DateTime(2026, 11, 21, 12, 0, 0), false,
            new() { 16, 17, 17, 18, 19 }),
    };

    public static List<FactionVm> FactionsForSystem(int systemId) =>
        Factions.Where(f => f.SystemId == systemId).ToList();

    public static List<UnitVm> UnitsForSystem(int systemId)
    {
        var factionIds = Factions.Where(f => f.SystemId == systemId).Select(f => f.Id).ToHashSet();
        return Units.Where(u => factionIds.Contains(u.FactionId)).ToList();
    }

    public static List<ArmyListSummaryVm> ArmyListsForSystem(int systemId) =>
        Lists.Where(l => l.SystemId == systemId)
            .OrderByDescending(l => l.UpdatedAt)
            .Select(l => new ArmyListSummaryVm
            {
                Id = l.Id,
                Name = l.Name,
                FactionId = l.FactionId,
                FactionName = Factions.First(f => f.Id == l.FactionId).Name,
                PointsLimit = l.PointsLimit,
                PointsTotal = l.UnitIds.Sum(id => Units.First(u => u.Id == id).Points),
                UnitCount = l.UnitIds.Count,
                UpdatedAt = l.UpdatedAt,
                IsImported = l.IsImported,
            })
            .ToList();

    /// <summary>Returns the list's system id and its editor form data, or null if there is no such list.</summary>
    public static (int SystemId, ArmyListInput Input)? FindArmyList(int id)
    {
        var l = Lists.FirstOrDefault(x => x.Id == id);
        if (l is null)
        {
            return null;
        }

        return (l.SystemId, new ArmyListInput
        {
            Name = l.Name,
            FactionId = l.FactionId,
            PointsLimit = l.PointsLimit,
            Entries = l.UnitIds.Select(u => new ArmyListEntryInput { UnitId = u }).ToList(),
        });
    }

    private static UnitVm U(int id, int factionId, string name, string category, int points, string stats, string? rules, bool custom = false)
    {
        var faction = Factions.First(f => f.Id == factionId);
        var keys = Systems.First(s => s.Id == faction.SystemId).Stats.Select(s => s.Key).ToList();
        var values = stats.Split('|');
        return new UnitVm
        {
            Id = id,
            FactionId = factionId,
            FactionName = faction.Name,
            Name = name,
            Category = category,
            Points = points,
            Stats = keys.Zip(values).ToDictionary(p => p.First, p => p.Second),
            Rules = rules,
            IsCustom = custom,
            AuthorName = custom ? "You" : null,
        };
    }

    private record SampleList(int Id, int SystemId, string Name, int FactionId, int PointsLimit,
        DateTime UpdatedAt, bool IsImported, List<int> UnitIds);
}
