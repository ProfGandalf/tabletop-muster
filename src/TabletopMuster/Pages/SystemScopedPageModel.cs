using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TabletopMuster.ViewModels;

namespace TabletopMuster.Pages;

/// <summary>
/// Base class for the logged-in pages that work inside one game system.
/// The chosen system travels in the query string (?system=1) and drives the picker in the navbar.
/// </summary>
public abstract class SystemScopedPageModel : PageModel
{
    [BindProperty(Name = "system", SupportsGet = true)]
    public int? SystemId { get; set; }

    public List<GameSystemVm> Systems { get; set; } = new();
    public GameSystemVm SelectedSystem { get; set; } = new();

    /// <summary>False on pages where switching system would throw away work (the list editor).</summary>
    public virtual bool AllowSystemSwitch => true;

    protected void LoadSystems()
    {
        // BACKEND TODO: load systems from the database. Optionally remember the user's last
        // chosen system (e.g. in a cookie or on the user) and use it when ?system is missing.
        Systems = SampleData.Systems;
        SelectedSystem = Systems.FirstOrDefault(s => s.Id == SystemId) ?? Systems.First();
        SystemId = SelectedSystem.Id;
    }
}
