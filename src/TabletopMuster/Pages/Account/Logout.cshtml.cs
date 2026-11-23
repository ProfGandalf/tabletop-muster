using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TabletopMuster.Pages.Account;

// FRONTEND STUB: the "Log out" item in the user menu posts here.
public class LogoutModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public LogoutModel(SignInManager<IdentityUser> signInManager) {
        _signInManager = signInManager;
    }

    // Logging out via a plain link (GET) is not allowed; just go back to the app.
    public IActionResult OnGet() => RedirectToPage("/Home");

    public async Task<IActionResult> OnPostAsync()
    {
        await _signInManager.SignOutAsync();
        return RedirectToPage("/Account/Login");
    }
}
