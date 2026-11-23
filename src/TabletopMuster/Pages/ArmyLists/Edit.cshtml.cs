using Microsoft.AspNetCore.Mvc;
using TabletopMuster.ViewModels;

namespace TabletopMuster.Pages.ArmyLists;

// FRONTEND STUB: the army list editor. /ArmyLists/Edit?system=1 creates a new list,
// /ArmyLists/Edit?id=5 edits an existing one.
// The browser keeps the points total up to date; on save the whole list arrives in Input
// (one Input.Entries item per squad).
// BACKEND TODO: replace the SampleData calls, save in OnPostAsync, and require login for this page.
public class EditModel : SystemScopedPageModel
{
    [BindProperty(SupportsGet = true)]
    public int? Id { get; set; }

    [BindProperty]
    public ArmyListInput Input { get; set; } = new();

    public List<FactionVm> Factions { get; set; } = new();

    /// <summary>Units the user can add: the selected system's catalogue plus their own custom units.</summary>
    public List<UnitVm> Units { get; set; } = new();

    public bool IsNew => Id is null;

    // Switching system in the middle of editing would lose the list, so the navbar shows it as text.
    public override bool AllowSystemSwitch => false;

    public IActionResult OnGet()
    {
        if (Id is not null)
        {
            // BACKEND TODO: load the list only if it belongs to the current user; otherwise NotFound().
            var found = SampleData.FindArmyList(Id.Value);
            if (found is null)
            {
                return NotFound();
            }

            SystemId = found.Value.SystemId;
            Input = found.Value.Input;
        }

        LoadPageData();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        LoadPageData();
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // BACKEND TODO:
        //  - check that Input.FactionId belongs to the selected system and every entry's unit
        //    belongs to that faction (built-in or the user's own custom unit);
        //  - recalculate the points total on the server (don't trust the browser);
        //  - create a new list (IsNew) or update list Id (only if it belongs to the current user).
        // Going over the points limit is allowed: the list is saved and shown with a warning.
        await Task.CompletedTask;
        TempData["StatusMessage"] = $"\"{Input.Name}\" is not saved yet: the backend is not connected.";
        return RedirectToPage("/Home", null, new { system = SystemId }, "lists");
    }

    private void LoadPageData()
    {
        LoadSystems();
        Factions = SampleData.FactionsForSystem(SelectedSystem.Id);
        Units = SampleData.UnitsForSystem(SelectedSystem.Id);
    }
}
