using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TabletopMuster.Pages.Account;

// FRONTEND STUB: the "Log out" item in the user menu posts here.
public class LogoutModel : PageModel
{
    // Logging out via a plain link (GET) is not allowed; just go back to the app.
    public IActionResult OnGet() => RedirectToPage("/Home");

    public async Task<IActionResult> OnPostAsync()
    {
        // BACKEND TODO: await _signInManager.SignOutAsync();
        await Task.CompletedTask;
        return RedirectToPage("/Account/Login");
    }
}
