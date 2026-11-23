using Microsoft.AspNetCore.Mvc;
using TabletopMuster.ViewModels;

namespace TabletopMuster.Pages;

// FRONTEND STUB: the main page after login (army lists + unit catalogue of the chosen system).
// The properties below are what Home.cshtml displays.
// BACKEND TODO: replace the SampleData calls with real queries, and require login for this page.
public class HomeModel : SystemScopedPageModel
{
    public List<FactionVm> Factions { get; set; } = new();

    /// <summary>All units of the selected system: the built-in catalogue plus the current user's custom units.</summary>
    public List<UnitVm> Units { get; set; } = new();

    /// <summary>The current user's army lists in the selected system (created and imported), newest first.</summary>
    public List<ArmyListSummaryVm> ArmyLists { get; set; } = new();

    [BindProperty]
    public IFormFile? ImportFile { get; set; }

    [BindProperty]
    public string? ImportText { get; set; }

    public void OnGet()
    {
        LoadPageData();
    }

    public async Task<IActionResult> OnPostImportAsync()
    {
        // BACKEND TODO: read ImportFile (or ImportText if no file was chosen), parse it,
        // check that its faction belongs to the selected system, and save it as an imported list
        // for the current user. On failure, set TempData["StatusMessage"] to a readable error.
        await Task.CompletedTask;
        TempData["StatusMessage"] = "Import is not connected to the backend yet.";
        return RedirectToPage("/Home", null, new { system = SystemId }, "lists");
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        // BACKEND TODO: delete army list `id` if it belongs to the current user.
        await Task.CompletedTask;
        TempData["StatusMessage"] = "Delete is not connected to the backend yet.";
        return RedirectToPage("/Home", null, new { system = SystemId }, "lists");
    }

    private void LoadPageData()
    {
        LoadSystems();
        Factions = SampleData.FactionsForSystem(SelectedSystem.Id);
        Units = SampleData.UnitsForSystem(SelectedSystem.Id);
        ArmyLists = SampleData.ArmyListsForSystem(SelectedSystem.Id);
    }
}
